using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using CommonNetworking;

namespace ServerNetworking
{
    public class Client
    {
        private Thread _ListeningThread; //this thread will be used to asynchronously check for new packets

        public bool Asyncreadflag = true; //this flag indicates if asynchronous reading thread are allowed to run

        public Session session; //the session this client belongs to 


        /* by using a reader and a writer, we don't have to lock the networkingstream in threads
         * so two different threads can read and write at the same time on it
         */
        public Reader reader
        {
            get; private set;
        }
        public Writer writer
        {
            get; private set;
        }

        private NetworkStream _nw_Stream
        {
            get { return client?.GetStream(); }
        }

        public enum Roles
        {
            Moderator,
            Viewer
        }

        public Roles role = Roles.Viewer; //this clients role in the session it belongs to

        public TcpClient client;


        /// <summary>
        /// initializes a client object with a tcpclient
        /// </summary>
        /// <param name="cl">the tcpclient to initialize this client object with</param>
        public Client(TcpClient cl)
        {
            client = cl;
            reader = new Reader(_nw_Stream);
            writer = new Writer(_nw_Stream);
        }


        //methods

        #region sessionhandling

        /// <summary>
        /// toggles the role of this client. Client becomes Moderator and Moderator becomes Viewer
        /// </summary>
        public void toggleRole()
        {
            if (role == Roles.Moderator) this.role = Roles.Viewer;
            else this.role = Roles.Moderator;
        }

        
        /// <summary>
        /// this method handles received session info packets
        /// </summary>
        /// <param name="infotype">
        /// the type of the packet that is supposed to be processed
        /// </param>
        private void handlesessioninfo(headers.infotype infotype)
        {
            //now forward the sessioninfo to the other client in the session
            foreach (var c in session.clients)
            {
                if (infotype == headers.infotype.EndSession) break;//don't forward endsession yet, because that is handled later
                if (c.role != this.role)
                {
                    c.forward(headers.packettype.SessionInfo, new byte[] { headers.infotypebytes[infotype] });
                }
            }

            switch (infotype)
            {
                case headers.infotype.EndSession: //moderator ended session -> delete the entire session
                    Console.WriteLine("[-] SessionEnd requested");
                    Asyncreadflag = false;
                    sendstring("ok"); //signalize client, that the message was received, so the connection can be closed from both sides

                    session.removeClient(this);
                    SessionManager.Instance.delete(session);
                    return;
                case headers.infotype.QuitSession: //viewer quit session -> remove this client from the session
                    sendstring("ok");
                    stopAsyncListening();
                    session.removeClient(this);
                    break;
                case headers.infotype.RequestAccepted: //a "get-Moderator" - Request was accepted -> toggle the roles of both clients
                    foreach (Client c in session.clients)
                    {
                        c.toggleRole();
                        c.sendCurrentSessionInfo();
                    }
                    break;
            }

        }

        /// <summary>
        /// sends the current session info to the client, including the sessionid and role
        /// </summary>
        public void sendCurrentSessionInfo()
        {
            try
            {
                sendrecv.sendStartPattern(writer);
                sendrecv.writeOnStream(writer, new byte[] { headers.packettypebytes[headers.packettype.SessionInfo] });
                sendrecv.writeOnStream(writer, new byte[] { headers.infotypebytes[headers.infotype.CurrentSessionInfo] });
                byte[] bytes = Encoding.UTF8.GetBytes(session.SessionID);
                sendrecv.writeOnStream(writer, BitConverter.GetBytes(bytes.Length));
                sendrecv.writeOnStream(writer, bytes);
                sendrecv.writeOnStream(writer, new byte[] { role == Roles.Moderator ? (byte)0 : (byte)1 });
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncListening();
                    handleConnectionProblems();
                }
            }
        }

        /// <summary>
        /// sends a sessioninfopacket to the client
        /// </summary>
        /// <param name="sessioninfo">the sessioninfo which is supposed to be sent</param>
        public void sendSessionInfo(headers.infotype sessioninfo)
        {
            try
            {
                sendrecv.sendStartPattern(writer);
                sendrecv.writeOnStream(writer, new byte[] { headers.packettypebytes[headers.packettype.SessionInfo] });
                sendrecv.writeOnStream(writer, new byte[] { headers.infotypebytes[sessioninfo] });
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncListening();
                    // not calling handleconnetionproblems here, because it would call it would cause a stack overflow
                    //because that method calls eventually session.delete which calls this method again
                }
            }
        }

        #endregion

        #region connection handling
        /// <summary>
        /// permanently sending a byte containing 1 to check every 1.5s to check if connection to client is broken
        /// </summary>
        void checkIfConnAlive()
        {
            while (Asyncreadflag)
            {
                if (!sendrecv.ConnectionAlive(writer))
                {
                    stopAsyncListening();
                    handleConnectionProblems();
                    break;
                }
                for (int i = 0; i < 15 && Asyncreadflag; i++) Thread.Sleep(100);  /*waiting 15 times 100ms instead of 1.5 s so this 
                                                                                    Thread doesn't prevent the client from stopping async
                                                                                    listening for too long*/
            }

        }

        
        /// <summary>
        /// this method decides what happens when connection problems occur.
        /// </summary>
        private void handleConnectionProblems()
        {
            Console.WriteLine($"[!] Couldn't Reach {role} in Session \"{session.SessionID}\"! deleting it from the session");
            if (session.clients.Count < 2)
            {
                Console.WriteLine($"[!] no clients left -> deleting session \"{session.SessionID}\"");
                session.delete(); //if there are less than two clients in the session, the session will be deleted

                return;
            }

            //get the other client in the session
            foreach (Client c in session.clients)
            {
                if (c.role != this.role)
                {
                    if (this.role == Roles.Moderator
                    ) //if moderator loses connection, the viewer gets a notification and becomes Moderator
                    {
                        Console.WriteLine("[*] deleting session...");
                        c.sendbyte(headers.packettypebytes[
                            headers.packettype.SessionPartnerHasConnectionProblems]);
                        session.delete();
                    }
                    else
                    {
                        //if viewer loses connection, the moderator gets a notification and the viewer is removed from the session
                        c.sendbyte(headers.packettypebytes[headers.packettype.SessionPartnerHasConnectionProblems]);
                        session.removeClient(this);
                        c.sendSessionInfo(headers.infotype.QuitSession);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// closes and kills the connection to the client
        /// </summary>
        public void close()
        {
            this.client.Close();
        }

        #endregion

        #region receiveing data
        /// <summary>
        /// this method receives a File and returns it as a byte array
        /// </summary>
        /// <returns>
        /// The received File as a byte-Array
        /// </returns>
        public byte[] receiveFile()
        {
            sendrecv.waitforstartpattern(reader);
            int len = BitConverter.ToInt32(sendrecv.readfromstream(reader, 4), 0);
            return sendrecv.readfromstream(reader, len);
        }

        /// <summary>
        /// continuesly waits for a new packet and calls depending on the packet type a method to handle
        /// the packet.
        /// only stops when an exception occurs or when the Asyncreadflag is set to false.
        /// </summary>
        private void reading()
        {
            try
            {
                while (Asyncreadflag)
                {
                    //wait for a new packet
                    sendrecv.waitforstartpattern(reader);
                    headers.packettype type = headers.packettypes[sendrecv.readfromstream(reader, 1)[0]]; //check the type of the packet

                    //if packet is not a sessioninfo packet forward it without looking at it
                    if (type != headers.packettype.SessionInfo)
                    {
                        Int32 datalength = BitConverter.ToInt32(sendrecv.readfromstream(reader, 4), 0);
                        byte[] data = sendrecv.readfromstream(reader, datalength);

                        foreach (Client c in session.clients)
                        {
                            if (c.role != this.role)
                            {
                                c.forward(type, data);
                                break;
                            }
                        }
                    }
                    //if the packet is a session info packet, the information is processed by the method handlesessioninfo
                    else if (type == headers.packettype.SessionInfo)
                    {
                        headers.infotype infotype = headers.infotypes[sendrecv.readfromstream(reader, 1)[0]];
                        handlesessioninfo(infotype);
                    }
                }
            }
            catch (Exception ex)
            {
                //ignore all exceptions after the moment this thread is supposed to end
                if (Asyncreadflag)
                {
                    Console.WriteLine(
                        $"Error in async reading for {role.ToString()} in session {this.session.SessionID}: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// starts two threads of which one continuesly checks if the connection is still alive
        /// and the other one continuesly checks for new packages
        /// </summary>
        public void startAsyncListening()
        {
            _ListeningThread = new Thread(reading);
            _ListeningThread.Start();
            //the following 
            Thread connceck = new Thread(checkIfConnAlive);
            connceck.Start();
        }

        /// <summary>
        /// stops all asynchrounous processes
        /// </summary>
        public void stopAsyncListening()
        {
            //safely end the threads, by setting the flags to false
            this.Asyncreadflag = false;
            reader.asyncreadflag = false;

        }


        #endregion

        #region senddata
        /// <summary>
        /// sends a File to the client
        /// </summary>
        /// <param name="filename">the path to the file</param>
        public void sendFile(string filename)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                sendrecv.writeOnStream(writer, headers.magicstartpattern);
                sendrecv.writeOnStream(writer, BitConverter.GetBytes((Int32)fi.Length));
                sendrecv.writeOnStream(writer, File.ReadAllBytes(filename));
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncListening();
                    handleConnectionProblems();
                }
            }
        }

        /// <summary>
        /// sends a packet containing a specified byte to the client
        /// </summary>
        /// <param name="b">the byte to send</param>
        public void sendbyte(byte b)
        {
            try
            {
                sendrecv.writeOnStream(writer, headers.magicstartpattern);
                sendrecv.writeOnStream(writer, new byte[] { b });
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncListening();
                    handleConnectionProblems();
                }
            }
        }

        /// <summary>
        /// forwards a packet to the client
        /// </summary>
        /// <param name="type">the type of the packet</param>
        /// <param name="data">the content of the packet</param>
        public void forward(headers.packettype type, byte[] data)
        {
            try
            {
                //send start pattern and entire packet structure as defined in headers.cs
                sendrecv.writeOnStream(writer, headers.magicstartpattern);
                sendrecv.writeOnStream(writer, new byte[] { headers.packettypebytes[type] });
                if (type != headers.packettype.SessionInfo) sendrecv.writeOnStream(writer, BitConverter.GetBytes(data.Length));
                sendrecv.writeOnStream(writer, data);
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncListening();
                    handleConnectionProblems();
                }
            }
        }

        /// <summary>
        /// sends a string to the client
        /// </summary>
        /// <param name="msg">the string to send</param>
        public void sendstring(string msg)
        {
            try
            {
                sendrecv.sendString(writer, msg);
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncListening();
                    handleConnectionProblems();
                }
            }
        }
        #endregion

        
    }
}