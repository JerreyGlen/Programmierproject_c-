using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface Synchronization
    {
        void Synchronize(byte[] FIledata);
        void SynchronizeCallBack(byte[] FIledata);
    }
}
