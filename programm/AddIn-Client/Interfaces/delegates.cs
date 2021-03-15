using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Interfaces
{
    public class delegates
    {
        public enum Roles
        {
            Moderator,
            Viewer
        }

        public delegate void ChatMSGCallBack(string msg);
        public delegate void IMGAvailableCallBack(byte[] commandinfo);
        public delegate void LaserPointerCallBack(string lpinfo);
        public delegate void SessionInfoCallBack(string sessionID, Roles role);
        public delegate void FileAvailableCallBack(byte[] file);
        public delegate void ModeratorRequestCallBack();
        public delegate void RequestAnswerCallBack(bool answer);
        public delegate void SessionEndedCallBack();
        public delegate void ViewerquitSessionCallBack();
        public delegate void ViewerJoinedSessionCallBack();
        public delegate void ConnectionProblemsCallBack(string msg);
    }
}
