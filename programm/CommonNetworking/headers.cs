using System;
using System.Collections.Generic;
using System.Text;

namespace CommonNetworking
{

    /*
     * each packet starts with a specific start pattern, followed by a byte which tells the type
     * of the packet and more bytes containing the packet content some examples:
     * 
     * packettype                         typebyte     content
     * 
     * File:                 startpattern   4           4bytes(32bit-integer for fileisze) + filebytes
     * currentsessioninfo    startpattern   0           infotypebyte(5) + 4bytes(32bit-integer for size of string) +  bytes of sessionid-string + 1byte(0 für Moderator, 1 für Viewer) 
     */
    public class headers
    {
        //there are different packettypes which are defined below
        public enum packettype
        {
            SessionInfo,
            Chat,
            IMG,
            LaserPointer,
            File,
            SessionPartnerHasConnectionProblems
        }

        //there are different sessioninfotype packets which are defined in the following enum
        public enum infotype
        {
            EndSession,
            QuitSession,
            RequestModerator,
            RequestAccepted,
            RequestDenied,
            CurrentSessionInfo,
            ViewerJoined
        }

        //the dictionaries below allow an easy conversion between a byte's value and the packet type they refer to as an enum value
        public readonly static Dictionary<byte, packettype> packettypes = new Dictionary<byte, packettype>()
        {
            {0, packettype.SessionInfo },
            {1, packettype.Chat },
            {2, packettype.IMG },
            {3, packettype.LaserPointer },
            {4, packettype.File },
            {5, packettype.SessionPartnerHasConnectionProblems }
        };
        public readonly static Dictionary<packettype, byte> packettypebytes = new Dictionary<packettype, byte>()
        {
            {packettype.SessionInfo, 0 },
            {packettype.Chat, 1 },
            {packettype.IMG, 2 },
            {packettype.LaserPointer, 3 },
            {packettype.File, 4 },
            {packettype.SessionPartnerHasConnectionProblems, 5 }
        };
        public readonly static Dictionary<byte, infotype> infotypes = new Dictionary<byte, infotype>()
        {
            {0, infotype.EndSession },
            {1, infotype.QuitSession},
            {2, infotype.RequestModerator },
            {3, infotype.RequestAccepted },
            {4, infotype.RequestDenied },
            {5, infotype.CurrentSessionInfo },
            {6, infotype.ViewerJoined }
        };
        public readonly static Dictionary<infotype, byte> infotypebytes = new Dictionary<infotype, byte>()
        {
            {infotype.EndSession, 0 },
            {infotype.QuitSession, 1 },
            {infotype.RequestModerator, 2 },
            {infotype.RequestAccepted ,3 },
            {infotype.RequestDenied, 4 },
            {infotype.CurrentSessionInfo, 5 },
            {infotype.ViewerJoined, 6 }
        };

        //the start pattern encoded as an UTF-8 string which is at the begin of each packet
        public readonly static byte[] magicstartpattern = Encoding.UTF8.GetBytes("KBANAFAFI");
    }
}
