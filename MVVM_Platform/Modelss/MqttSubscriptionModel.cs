using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MQTTnet.Protocol;
using Newtonsoft.Json;

namespace Models
{
    public class MqttSubscriptionModel
    {
        /// <summary>
        /// 订阅信息
        /// </summary>
        public string Topic { get; set; }

        public MqttQualityOfServiceLevel Qos { get; set; }
        /// <summary>
        /// 标记
        /// </summary>
        public string Sign { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string OtherName { get; set; }
        /// <summary>
        /// 订阅标识符
        /// </summary>
        public int SubscriptionID { get; set; }
        /// <summary>
        /// 禁止本地转发
        /// </summary>
        public bool DisableLocalForwarding { get; set; }
        /// <summary>
        /// 发布时保留状态
        /// </summary>
        public bool StateRetention { get; set; }

        public uint KeepMessageHandling { get; set; }
        [JsonIgnore]//不会存储到log内
        public List<string> ReceiveMessages { get; set; }
    }
}
