using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using CommonNetworking;

namespace ServerNetworking
{
    public class SessionManager
    {
        #region SingletonImplementation

        private static SessionManager sm;

        public static SessionManager Instance //singleton implementation
        {
            get
            {
                if (sm == null)
                {
                    sm = new SessionManager();
                    return sm;
                }
                else return sm;
            }
        }

        #endregion

        /// <summary>
        /// constructor
        /// </summary>
        private SessionManager()
        {
            sessions = new List<Session>();
        }

        public List<Session> sessions;

        /// <summary>
        /// deletes the specified session
        /// </summary>
        /// <param name="s">the session that is supposed to end/be deleted</param>
        public void delete(Session s)
        {
            s.delete();
        }

        /// <summary>
        /// creates a new session
        /// </summary>
        /// <param name="cl">
        ///    the tcpclient which requests a new session
        /// </param>
        public void createnew(TcpClient cl)
        {
            Session s = new Session(new Client(cl));
            
            sessions.Add(s); //adding the session to the list of active sessions
        }

        /// <summary>
        /// this method checks if it is possible to add a specified tcpclient to the specified session and if so adds the client to the session.
        /// </summary>
        /// <param name="id">the id of the session the client is requesting to be added to</param>
        /// <param name="cl">the client which is supposed to be added</param>
        /// <returns>
        ///    returns a bool value. true = successfully added. false = couldn't add client to the specified session
        /// </returns>
        public bool addToSession(string id, TcpClient cl)
        {
            foreach (Session s in sessions)
            {
                if (s.SessionID == id && s.clients.Count < 2
                ) //checking if session exists and if so if it isn't already full
                {
                    s.Add(new Client(cl));
                    return true;
                }
            }

            return false;
        }
    }
}