using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationComponent
{
    public class MessageReceivedArg : EventArgs
    {
        public string Topic { get; internal set; }
        public string Payload { get; internal set; }

    }
}
