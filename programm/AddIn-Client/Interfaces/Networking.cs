using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface Networking
    {
        /// <summary>
        /// invoked, once a viewer joined the session
        /// </summary>
        event delegates.ViewerJoinedSessionCallBack ViewerJoinedSession;
        /// <summary>
        /// invoked once a new Chat-Message is available.
        /// </summary>
        event delegates.ChatMSGCallBack ChatMSGAvailable;
        /// <summary>
        /// invoked once a new streaming-image is available.
        /// </summary>
        event delegates.IMGAvailableCallBack IMGAvailable;
        /// <summary>
        /// invoked once new Laserpointerinfo is available.
        /// </summary>
        event delegates.LaserPointerCallBack LaserPointerInfoAvailable;
        /// <summary>
        /// invoked once a file is available
        /// </summary>
        event delegates.FileAvailableCallBack FileAvailable;
        /// <summary>
        /// invoked, once a session info is available
        /// </summary>
        event delegates.SessionInfoCallBack SessionInfoAvailable;
        /// <summary>
        /// invoked, once the viewer quit the session
        /// </summary>
        event delegates.ViewerquitSessionCallBack ViewerQuitSession;
        /// <summary>
        /// is invoked, when the session ends
        /// </summary>
        event delegates.SessionEndedCallBack SessionEnded;
        /// <summary>
        /// invoked once the server is not reachable for more than a specific amount of seconds
        /// </summary>
        event delegates.ConnectionProblemsCallBack ConnectionProblems;
        /// <summary>
        /// invoked on the moderators machine, once the client requests to become moderator
        /// </summary>
        event delegates.ModeratorRequestCallBack ModeratorRequest;
        /// <summary>
        /// invoked once an answer for a Moderator request is available
        /// </summary>
        event delegates.RequestAnswerCallBack RequestAnswerAvailable;
        void sendChatMSG(string msg);
        void sendIMG(byte[] ImageData);
        void sendLaserPointerInfo(LaserPointerInfo lpinfo);

        /// <summary>
        /// sends the specified file
        /// </summary>
        /// <param name="FilePath"></param>
        void sendFile(string FilePath);

        /// <summary>
        /// connects the client to the server with the specified session id and 
        /// sends (and eventually receives a file) for file synchronisation
        /// </summary>
        /// <param name="sessionid">the session which the user wants to join. "new" to create a new one</param>
        /// <param name="filepath">the path to the file which is supposed to be synchronised</param>
        void connect(string sessionid, string filepath);
        
        void disconnect();

    }
}
