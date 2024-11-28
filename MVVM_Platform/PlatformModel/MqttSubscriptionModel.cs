using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Protocol;

namespace PlatformModel
{
    public class MqttSubscriptionModel
    {
        public string Topic { get; set; }

        public MqttQualityOfServiceLevel Qos { get; set; }

        public string OtherName { get; set; }

        public int SubscriptionID { get; set; }

        public bool DisableLocalForwarding { get; set; }
        public bool StateRetention { get; set; }

        public uint KeepMessageHandling { get; set; }
    }
}
