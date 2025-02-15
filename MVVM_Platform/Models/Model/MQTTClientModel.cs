﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Models
{
    public class MQTTClientModel
    {
        public string Name { get; set; }
        /// <summary>名称</summary>
        public string ClientID { get; set; } = Guid.NewGuid().ToString();
        /// <summary>用户名</summary>
        public string UserName { get; set; } = "admin";
        /// <summary>密码</summary>
        public string UserPassWord { get; set; } = "123456";
        /// <summary>生存确认</summary>
        public uint KeepAlive { get; set; } = 60;
        /// <summary>清除状态</summary>
        public bool CleanStart { get; set; }
        public bool IsConnected { get; set; }
        public int Port { get; set; } = 1883;
        public string Host { get; set; } = "127.0.0.1";
        public uint MqttVersions { get; set; } = 0;

        public bool IsSSL { get; set; } = false;
        public ServerAddress ServerAddress { get; set; } = ServerAddress.mqtt;
        public int ConnectTimeOut { get; set; } = 10;

        /// <summary>订阅主题集合</summary>
        public ObservableCollection<MqttSubscriptionModel> listTopic { get; set; } = new();
    }
    public enum ServerAddress
    {
        mqtt,
        mqtts,
        ws,
        wss
    }
}
