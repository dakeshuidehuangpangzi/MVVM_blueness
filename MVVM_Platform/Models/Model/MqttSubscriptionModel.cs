using System;
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
        [ObservableProperty]
        string topic  = "te";
        [ObservableProperty]

        MqttQualityOfServiceLevel qos  = MqttQualityOfServiceLevel.AtMostOnce;
        /// <summary>
        /// 标记
        /// </summary>
        [ObservableProperty]
        string sign = "Sign";
        /// <summary>
        /// 别名
        /// </summary>
        [ObservableProperty]
        string otherName = "test";
        /// <summary>
        /// 订阅标识符
        /// </summary>
        [ObservableProperty]
        int subscriptionID;
        /// <summary>
        /// 禁止本地转发
        /// </summary>
        [ObservableProperty]
        bool disableLocalForwarding  = false;
        /// <summary>
        /// 发布时保留状态
        /// </summary>
        [ObservableProperty]

        bool stateRetention = false;
        [ObservableProperty]

        uint keepMessageHandling;
        [JsonIgnore]//不会存储到log内
        [ObservableProperty]
        List<MqttMessageInfo> receiveMessages;

    }
}
