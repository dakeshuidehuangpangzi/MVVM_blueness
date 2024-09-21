using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcPlatform
{
    public abstract class CommunicationBase
    {
        /// <summary>连接状态</summary>
        public virtual bool ConnectState { get; set; } = false;
        /// <summary>读取</summary>
        public abstract void Read(IEnumerable<object> value, Func<object> CallBack);
        public abstract bool Write(IEnumerable<object> value);

        public abstract Result<List<byte>> SendAndReceived(IEnumerable<byte> req,int len1, int timeout, Func<byte[], int> calcLen = null);

        public abstract Result Connect(int trycount = 20);
        public abstract Result Close();
    }
}
