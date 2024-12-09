﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MQTTnet.Protocol;
using Newtonsoft.Json;

namespace Models
{
    public partial class MqttSubscriptionModel: ObservableObject
    {
        /// <summary>
        /// 订阅信息
        /// </summary>
        public string Topic { get; set; } = "te";

        public MqttQualityOfServiceLevel Qos { get; set; } = MqttQualityOfServiceLevel.AtMostOnce;
        /// <summary>
        /// 标记
        /// </summary>
        public string Sign { get; set; } = "Sign";
        /// <summary>
        /// 别名
        /// </summary>
        public string OtherName { get; set; } = "test";
        /// <summary>
        /// 订阅标识符
        /// </summary>
        public int SubscriptionID { get; set; }
        /// <summary>
        /// 禁止本地转发
        /// </summary>
        public bool DisableLocalForwarding { get; set; } = false;
        /// <summary>
        /// 发布时保留状态
        /// </summary>
        public bool StateRetention { get; set; } = false;

        public uint KeepMessageHandling { get; set; }
        [JsonIgnore]//不会存储到log内
        public List<string> ReceiveMessages { get; set; }
    }
}
