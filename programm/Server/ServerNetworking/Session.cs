using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
using CommonNetworking;
using System.Threading;

namespace ServerNetworking
{
    public class Session
    {
        
        public List<Client> clients; //the list of clients that currently are in the session
           
        public string SessionID;    //the id of the session

        private SHA256 sha256 = SHA256.Create();       //the sha256-object used to create hashes

        
        /// <summary>
        /// initializes a session with first client which is going to be the moderator of the session
        /// </summary>
        /// <param name="cl"></param>
        public Session(Client cl)
        {
            clients = new List<Client>(2);
            SessionID = CreateID();
            cl.role = Client.Roles.Moderator;
            Add(cl);
        }

        /// <summary>
        /// creates a random string
        /// </summary>
        /// <returns>the created string</returns>
        private static string CreateID()
        {
            Random random = new Random();
            string alphabet = "abcdefghijklmnopqrstuvwxyz_1234567890";
            return new string(Enumerable.Repeat(alphabet, 7).Select(s => s[random.Next((alphabet.Length - 1))]).ToArray());
        }

        /// <summary>
        /// this method compares to files by comparing their sha256-hash-values
        /// </summary>
        /// <param name="filea"></param>
        /// <param name="fileb"></param>
        /// <returns></returns>
        private bool filecomparison(byte[] filea, byte[] fileb)
        {
            if (sha256.ComputeHash(filea).SequenceEqual(sha256.ComputeHash(fileb))) return true;
            return false;
        }

        /// <summary>
        /// adds a client to this session
        /// </summary>
        /// <param name="cl">the client to add</param>
        public void Add(Client cl)
        {
            clients.Add(cl);
            cl.session = this;
            Console.WriteLine($"[*] new Client joined the session {SessionID}");
            //inform the client that it was added successfully
            cl.sendstring("ok");
            //receive file from client that joins
            byte[] file = cl.receiveFile();
            if (cl.role == Client.Roles.Moderator)//if cl is the moderator this file is saved on harddrive
            {
                File.WriteAllBytes($"{SessionID}.file", file);
            }

            if (cl.role == Client.Roles.Viewer) //if cl is viewer(usually second to join this session  its file is compared the one saved on the harddrive)
            {
                if (filecomparison(File.ReadAllBytes($"{SessionID}.file"), file))
                {
                    cl.sendbyte(0);
                }
                else
                {
                    cl.sendbyte(1);
                    cl.sendFile($"./{SessionID}.file");
                }
                //informing the moderator of the session, that the viewer joined
                foreach (Client c in clients)
                {
                    if (c.role == Client.Roles.Moderator)
                    {
                        c.sendSessionInfo(headers.infotype.ViewerJoined);
                    }
                }
            }

            cl.sendCurrentSessionInfo();//informing cl about which session it joined an its role in it
            cl.startAsyncListening(); //starting its asynchronous reading 
        }

        /// <summary>
        /// removes a client from the session
        /// </summary>
        /// <param name="c">the client which is supposed to be removed</param>
        public void removeClient(Client c)
        {
            clients.Remove(c);
            c.stopAsyncListening();
            Console.WriteLine($"[*] {c.role} in Session \"{SessionID}\" removed");
            c.close();

        }

        /// <summary>
        /// deletes this session
        /// </summary>
        public void delete()
        {
            //delete the file of this session
            var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            File.Delete(SessionID + ".file");

            //first safely remove all clients from this session
            while (clients.Count > 0)
            {
                clients[0].Asyncreadflag = false;
                clients[0].sendSessionInfo(headers.infotype.EndSession);
                for (int i = 0; i < 15; i++)                              //waiting maximum of 15 seconds for the client to receive message and disconnect
                {
                    if (!sendrecv.ConnectionAlive(clients[0].writer)) break;
                    Thread.Sleep(100);
                }
                removeClient(clients[0]);
            }

            //then remove this session from the sessions list of the sessionmanager
            foreach (Session s in SessionManager.Instance.sessions)
            {
                if (s.SessionID == SessionID)
                {
                    SessionManager.Instance.sessions.Remove(s);
                    break;
                }
            }

            Console.WriteLine($"[*] Session \"{SessionID}\" ended!");
        }

    }
}
