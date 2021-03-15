using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using CommonNetworking;

namespace ServerNetworking
{
    public class Server
    {
        private SessionManager sessionManager;

        public int Port; //the port this server listens on

        private TcpListener _Listener; //the listener used to listen for new clients

        private Thread _listeningThread;     //the thread in which the server asynchronously waits for new clients

        private bool _asyncreadflag = true; //flag which represents if the thread to asyncrhronously accept tcp connections is allowed to continue


        /// <summary>
        /// Constructor, which is initialized the Server with a specified listening port
        /// </summary>
        /// <param name="Port">
        /// port on which the server is supposed to listen for new clients
        /// </param>
        public Server(int Port)
        {
            sessionManager = SessionManager.Instance;
            this.Port = Port;
        }

        /// <summary>
        /// returns a task which handles a client after a connection was established
        /// </summary>
        /// <param name="cl"></param>
        /// <returns></returns>
        Task handleClient(TcpClient cl)
        {
            Reader r = new Reader(cl.GetStream());
            Writer w = new Writer(cl.GetStream());
            return Task.Factory.StartNew(() =>
            {
                string data = sendrecv.waitforstring(r); //if the client sends 'new' a new session is created
                if (data == "new")
                {
                    sessionManager.createnew(cl);
                }
                else //if the client sends something else, the sessionmanager checks if
                     //it is a valid session and adds if possible the client to it and if not answers 'error'
                {
                    bool sessavailable = sessionManager.addToSession(data, cl);
                    if (!sessavailable) sendrecv.sendString(w, "error");
                }
            });
        }

        /// <summary>
        /// this method continuesly waits for new clients and handles them asynchronously by starting a new task
        /// </summary>
        private async void listening()
        {
            try
            {
                //start the listener
                _Listener.Start();
                TcpClient tmp;
                while (_asyncreadflag)
                {
                    if (_Listener.Pending()
                    ) //only call accepttcpclient method when a connection request is pending, since the method is a blocking method
                    {
                        tmp = _Listener.AcceptTcpClient();
                        handleClient(tmp); //asynchronously handled so it doesn't prevent other clients from connecting...
                    }
                    else Thread.Sleep(20); //wait 20ms to relieve the cpu
                }
            }
            catch (Exception ex)
            {
                if (_asyncreadflag)
                    Console.WriteLine(
                        $"[!] An Error occured in the tcp-accepting-Thread!!!(Message: {ex.Message})"); /*ignoring exceptions after the thread was aborted*/
            }
        }

        /// <summary>
        /// starts the server
        /// </summary>
        public void start()
        {
            _Listener = new TcpListener(IPAddress.Any, Port);
            _Listener.Start();
            _listeningThread = new Thread(listening);
            _listeningThread.Start();

            Console.WriteLine("[*] Server gestartet");
        }


        /// <summary>
        /// stops the server
        /// </summary>
        public void stop()
        {
            Console.WriteLine("[*] aborting Listening-Thread....");
            _asyncreadflag = false;
            Console.WriteLine("[*] deleting all open sessions...");
            while (sessionManager.sessions.Count > 0)
                sessionManager.sessions[0].delete();

        }
    }
}