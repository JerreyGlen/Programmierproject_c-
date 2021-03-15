using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using CommonNetworking;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Networking
{
    public class Networking : Interfaces.Networking
    {
        #region events
        /// <summary>
        /// invoked, once a viewer joined the session
        /// </summary>
        public event delegates.ViewerJoinedSessionCallBack ViewerJoinedSession;
        /// <summary>
        /// invoked once a new Chat-Message is available.
        /// </summary>
        public event delegates.ChatMSGCallBack ChatMSGAvailable;
        /// <summary>
        /// invoked once a new streaming-image is available.
        /// </summary>
        public event delegates.IMGAvailableCallBack IMGAvailable;
        /// <summary>
        /// invoked once new Laserpointerinfo is available.
        /// </summary>
        public event delegates.LaserPointerCallBack LaserPointerInfoAvailable;
        /// <summary>
        /// invoked once a file is available
        /// </summary>
        public event delegates.FileAvailableCallBack FileAvailable;
        /// <summary>
        /// invoked, once a session info is available
        /// </summary>
        public event delegates.SessionInfoCallBack SessionInfoAvailable;
        /// <summary>
        /// invoked, once the viewer quit the session
        /// </summary>
        public event delegates.ViewerquitSessionCallBack ViewerQuitSession;
        /// <summary>
        /// is invoked, when the session ends
        /// </summary>
        public event delegates.SessionEndedCallBack SessionEnded;
        /// <summary>
        /// invoked once the server is not reachable for more than a specific amount of seconds
        /// </summary>
        public event delegates.ConnectionProblemsCallBack ConnectionProblems;
        /// <summary>
        /// invoked on the moderators machine, once the client requests to become moderator
        /// </summary>
        public event delegates.ModeratorRequestCallBack ModeratorRequest;
        /// <summary>
        /// invoked once an answer for a Moderator request is available
        /// </summary>
        public event delegates.RequestAnswerCallBack RequestAnswerAvailable;
        #endregion

        public bool asReading = false; ///flag which represents if the asynchronous reading thread is allowed to run

        private Reader _Reader;
        private Writer _Writer;

        private Thread readingThread; ///the thread in which the asynchronous data reception is happening

        private delegates.Roles Role; //the current role

        public bool connected { get; private set; } //states if the client is connected to the server


        //private tcp properties:
        TcpClient client;
        string ServerHostName = Settings.Default.Hostname; /*
                                                            * the hostname of the server can be changed in the settings file
                                                            * default is "localhost"
                                                            */

        NetworkStream nw_Stream
        {
            get
            {
                return client?.GetStream();
            }
        }



        /// <summary>
        /// connects the client to the specified session on the server
        /// </summary>
        /// <param name="sessionid"></param>
        public void connect(string sessionid, string FilePath)
        {
            try
            {
                if (!File.Exists(FilePath)) throw new Exception("Datei nicht vorhanden"); //checking if the file is available



                //connecting to the server with the specified session id:
                
                TcpClient cl = new TcpClient(ServerHostName, 4444);
                _Reader = new Reader(cl.GetStream());
                _Writer = new Writer(cl.GetStream());

                sendrecv.sendString(_Writer, sessionid);

                string received_data = sendrecv.waitforstring(_Reader); //waiting for server's Response 
                if (received_data != "ok") throw new Exception("Session not available or already full..."); //checking if connection query was valid(if server sends ok it is)

                //file comparison - sending specified file from "FilePath" first
                FileInfo fi = new FileInfo(FilePath);
                sendrecv.sendStartPattern(_Writer);
                sendrecv.writeOnStream(_Writer, BitConverter.GetBytes((Int32)fi.Length));
                sendrecv.writeOnStream(_Writer, File.ReadAllBytes(FilePath));

                //if file is not identical to the file stored in the session on the server the server sends new and the current file is overwritten by the new one from the server
                if (sessionid != "new")
                {
                    sendrecv.waitforstartpattern(_Reader);
                    if (sendrecv.readfromstream(_Reader, 1)[0] == 1)
                    {
                        sendrecv.waitforstartpattern(_Reader);
                        int len = BitConverter.ToInt32(sendrecv.readfromstream(_Reader, 4), 0);
                        File.Delete(FilePath);
                        File.WriteAllBytes(FilePath, sendrecv.readfromstream(_Reader, len));
                    }
                }
                Console.WriteLine("[*] Dateiaustausch abgeschlossen");
                this.client = cl;
                startAsyncRead();

                connected = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Connection Error: " + ex.Message);
            }
        }

        /// <summary>
        /// this method is continuesly waiting for new data on the networking stream,
        /// determines the type of the data and calls depending on the type methods to handle this data
        /// </summary>
        void reading()
        {
            try
            {
                while (asReading)
                {
                    sendrecv.waitforstartpattern(_Reader); /* waiting for a startpattern(each packet starts with a start pattern.)
                                                             the entire messaging protocol is defined and explained in the headers.cs file. */
                    if (asReading)
                    {
                        headers.packettype type = headers.packettypes[sendrecv.readfromstream(_Reader, 1)[0]]; /*this line reads the first byte of the packet and
                                                                                                             converts it to a packet-type-enum-value*/
                        if (type == headers.packettype.Chat) receiveChat();
                        if (type == headers.packettype.IMG) receiveimg();
                        if (type == headers.packettype.LaserPointer) receivelaserpointer();
                        if (type == headers.packettype.SessionInfo) handlesessioninfo();
                        if (type == headers.packettype.File) receiveFile();
                        if (type == headers.packettype.SessionPartnerHasConnectionProblems) PartnerhasConnectionProblems();
                    }
                }
            }
            catch (Exception ex)
            {
                if (asReading) throw new Exception($"Fehler beim asynchronen Lesen des netzwerkstreams: {ex.Message}"); /*ignoring exceptions which are thrown after the 
                                                                                                                       asynchronous reading was supposed to end. */
            }
        }


        //sending data:
        #region send data

        /// <summary>
        /// sends the specified laserpointerinfo object as a serialized json string
        /// </summary>
        /// <param name="LPInfo">
        /// the laserpointerinfo object which is supposed to be sent
        /// </param>
        public void sendLaserPointerInfo(LaserPointerInfo LPInfo)
        {
            try
            {
                sendrecv.sendStartPattern(_Writer);
                sendrecv.writeOnStream(_Writer, new byte[] { headers.packettypebytes[headers.packettype.LaserPointer] });
                string jsonlpinfo = JsonConvert.SerializeObject(LPInfo);
                byte[] bytes = Encoding.UTF8.GetBytes(jsonlpinfo); //serializing lpinfo object and converting it to a byte array
                sendrecv.writeOnStream(_Writer, BitConverter.GetBytes((Int32)bytes.Length));
                sendrecv.writeOnStream(_Writer, bytes); //sending the laserpointerinfo
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncRead();
                    ConnectionProblems.Invoke("Partner has ConnectionProblems");
                }
            }
        }

        /// <summary>
        /// send the specified file.
        /// </summary>
        /// <param name="filepath">
        /// the path to the file which is supposed to be sent.
        /// </param>
        public void sendFile(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) throw new FileNotFoundException();
                sendrecv.sendStartPattern(_Writer);
                sendrecv.writeOnStream(_Writer, new byte[] { headers.packettypebytes[headers.packettype.File] });
                FileInfo fi = new FileInfo(filepath);
                byte[] len = BitConverter.GetBytes((Int32)fi.Length);
                sendrecv.writeOnStream(_Writer, len);
                sendrecv.writeOnStream(_Writer, File.ReadAllBytes(filepath));
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncRead();
                    ConnectionProblems.Invoke("Partner has ConnectionProblems");
                }
            }
        }

        /// <summary>
        /// sends a request to become moderator
        /// </summary>
        public void requestModerator()
        {
            sendrecv.sendStartPattern(_Writer);
            sendrecv.writeOnStream(_Writer, new byte[] {headers.packettypebytes[headers.packettype.SessionInfo] });
            sendrecv.writeOnStream(_Writer, new byte[] {headers.infotypebytes[headers.infotype.RequestModerator] });
        }

        /// <summary>
        /// sends a request answer
        /// </summary>
        /// <param name="accepted">
        /// true means accepted and false means denied
        /// </param>
        public void sendRequestAnswer(bool accepted)
        {
            sendrecv.sendStartPattern(_Writer);
            sendrecv.writeOnStream(_Writer, new byte[] {headers.packettypebytes[headers.packettype.SessionInfo] });
            if (accepted) sendrecv.writeOnStream(_Writer, new byte[] {headers.infotypebytes[headers.infotype.RequestAccepted] });
            else sendrecv.writeOnStream(_Writer, new byte[] { headers.infotypebytes[headers.infotype.RequestDenied] });
        }


        /// <summary>
        /// sends the specified chat message
        /// </summary>
        /// <param name="msg">the chat message which is supposed to be sent</param>
        public void sendChatMSG(string msg)
        {
            try
            {
                sendrecv.sendStartPattern(_Writer);
                sendrecv.writeOnStream(_Writer, new byte[] { headers.packettypebytes[headers.packettype.Chat] });
                byte[] bytes = Encoding.UTF8.GetBytes(msg);
                sendrecv.writeOnStream(_Writer, BitConverter.GetBytes(bytes.Length));
                sendrecv.writeOnStream(_Writer, bytes);
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncRead();
                    ConnectionProblems.Invoke("Partner has ConnectionProblems");
                }
            }
        }

        /// <summary>
        /// sends the specified image data as a byte array
        /// </summary>
        /// <param name="imgdata">
        /// the specified image data as a byte array
        /// </param>
        public void sendIMG(byte[] imgdata)
        {
            try
            {
                sendrecv.sendStartPattern(_Writer);
                sendrecv.writeOnStream(_Writer, new byte[] { headers.packettypebytes[headers.packettype.IMG] });
                sendrecv.writeOnStream(_Writer, BitConverter.GetBytes(((Int32)imgdata.Length)));
                sendrecv.writeOnStream(_Writer, imgdata);
            }
            catch (Exception ex)
            {
                if (ex is ConnectionNotWorkingException)
                {
                    stopAsyncRead();
                    ConnectionProblems.Invoke("Partner has ConnectionProblems");
                }
            }
        }

        /// <summary>
        /// continuesly check every 1.5s if the connection is still alive
        /// </summary>
        void checkIfConnAlive()
        {
            try
            {
                while (asReading)
                {
                    sendrecv.writeOnStream(_Writer, new byte[] { 1 });
                    for (int i = 0; i < 15 && asReading; i++) Thread.Sleep(100);  /*waiting 15 times 100ms instead of 1.5 s so this 
                                                                                                        Thread doesn't prevent the client from stopping async
                                                                                                        listening for too long*/
                }
            }
            catch
            {
                stopAsyncRead();
                ConnectionProblems.Invoke("Server is unreachable");
                connected = false;
            }
        }
        #endregion

        //receiving data:
        #region receiving data

        /// <summary>
        /// invokes the connectionproblems event to inform that the session partner has connection problems
        /// </summary>
        private void PartnerhasConnectionProblems()
        {
            ConnectionProblems.Invoke("Lost Connection to Partner");
        }

        /// <summary>
        /// handles a sessioninfo packet
        /// </summary>
        private void handlesessioninfo()
        {
            headers.infotype infotype = headers.infotypes[sendrecv.readfromstream(_Reader, 1)[0]]; //first get the infotype of the sessioninfopacket

            //handle the packet depending on the type of the packet
            switch (infotype)
            {
                case headers.infotype.CurrentSessionInfo:
                    Int32 idlength = BitConverter.ToInt32(sendrecv.readfromstream(_Reader, 4), 0);
                    string id = Encoding.UTF8.GetString(sendrecv.readfromstream(_Reader, idlength));
                    byte role = sendrecv.readfromstream(_Reader, 1)[0];
                    this.Role = role == 0 ? delegates.Roles.Moderator : delegates.Roles.Viewer;
                    SessionInfoAvailable.Invoke(id, role == 0 ? delegates.Roles.Moderator : delegates.Roles.Viewer);
                    break;
                case headers.infotype.EndSession:
                    stopAsyncRead();
                    SessionEnded.Invoke();
                    break;
                case headers.infotype.ViewerJoined:
                    ViewerJoinedSession.Invoke();
                    break;
                case headers.infotype.QuitSession:
                    ViewerQuitSession.Invoke();
                    break;
                case headers.infotype.RequestModerator:
                    ModeratorRequest.Invoke();
                    break;
                case headers.infotype.RequestDenied:
                    RequestAnswerAvailable.Invoke(false);
                    break;
                case headers.infotype.RequestAccepted:
                    RequestAnswerAvailable.Invoke(true);
                    break;
            }
            
        }

        /// <summary>
        /// receives a laseerpointerinfo packet and invokes the laserpointerinfoavailable event
        /// </summary>
        private void receivelaserpointer()
        {
            byte[] len = sendrecv.readfromstream(_Reader, 4);
            string LPIinfoAsJson = Encoding.UTF8.GetString(sendrecv.readfromstream(_Reader, BitConverter.ToInt32(len, 0)));
            LaserPointerInfoAvailable.Invoke(LPIinfoAsJson);
        }

        

        /// <summary>
        /// receives a file and invokes the fileavailable event
        /// </summary>
        private void receiveFile()
        {
            int len = BitConverter.ToInt32(sendrecv.readfromstream(_Reader, 4), 0);
            byte[] file = sendrecv.readfromstream(_Reader, len);
            FileAvailable.Invoke(file);
        }
        private void receiveimg()
        {
            Int32 imgsize = BitConverter.ToInt32(sendrecv.readfromstream(_Reader, 4), 0);
            byte[] imgdata = sendrecv.readfromstream(_Reader, imgsize);
            IMGAvailable.Invoke(imgdata);
        }
        private void receiveChat()
        {
            Int32 msglength = BitConverter.ToInt32(sendrecv.readfromstream(_Reader, 4), 0);
            string msg = Encoding.UTF8.GetString(sendrecv.readfromstream(_Reader, msglength));
            ChatMSGAvailable.Invoke(msg);
        }

        #endregion

        //thread handling:
        #region thread handling
        /// <summary>
        /// starts two parallel threads wich execute the "reading"-method, to receive data asynchronously
        /// and the "checkifalive"-method, to check if the current connection is still alive
        /// </summary>
        public void startAsyncRead()
        {
            asReading = true;
            readingThread = new Thread(reading);
            readingThread.Start();
            Thread CheckConn = new Thread(checkIfConnAlive);
            CheckConn.Start();
        }
        /// <summary>
        /// stops the asynchronous reading thread
        /// </summary>
        public void stopAsyncRead()
        {
            _Reader.asyncreadflag = false;
            asReading = false;
        }
        #endregion

        /// <summary>
        /// disconnects the client from the server
        /// </summary>
        public void disconnect()
        {
            if (!connected) return;
            asReading = false;
            if (this.Role == delegates.Roles.Moderator)
            {
                sendrecv.sendend(_Writer);

                for (int i = 0; i < 15; i++)                              //waiting maximum of 15 seconds for the server to receive message and disconnect
                {
                    if (!sendrecv.ConnectionAlive(_Writer)) break;
                    Thread.Sleep(100);
                }
                
                stopAsyncRead();
                connected = false;
                
            }
            else if (this.Role == delegates.Roles.Viewer)
            {
                sendrecv.sendquit(_Writer);
                for (int i = 0; i < 15; i++)                              //waiting maximum of 15 seconds for the server to receive message and disconnect
                {
                    if (!sendrecv.ConnectionAlive(_Writer)) break;
                    Thread.Sleep(100);
                }
                stopAsyncRead();
                connected = false;
            }
        }
    }
}
