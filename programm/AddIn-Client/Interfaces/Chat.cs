using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public abstract class Chat
    {
        public abstract void display();
        public abstract void hide();
        public abstract void MSGCallBack(string msg);
    }
}
