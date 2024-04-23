using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponent
{
    public abstract class AbsUnit
    {


        public abstract Result Connect();
        public abstract void BeginConnect(int tryCont = 30);
        public abstract void Close();
        internal virtual Result<List<byte>> SendAndReceived(List<byte> req, int len1, int len2, int timeout) => null;

        //连接
       public  ManualResetEvent TimeoutObject = new ManualResetEvent(false);
    }
}
