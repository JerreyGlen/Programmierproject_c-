using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface Streaming
    {
        void displayStreamingWindow();

        void hideStreamingWindow();
        void IMGreceivedCallBack(byte[] ImageData);
        void sendIMG(byte[] imgdata);
    }
}
