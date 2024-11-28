using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreTest.Models
{
    public partial class MqttList
    {
        /// <summary>名称</summary>
        public string Name { get; set; }
        /// <summary>名称</summary>
        public string ClientID { get; set; } 
        /// <summary>用户名</summary>
        public string UserName { get; set; }
        /// <summary>密码</summary>
        public string UserPassWord { get; set; }
        /// <summary>生存确认</summary>
        public uint KeepAlive { get; set; }
        /// <summary>清除状态</summary>
        public bool CleanStart { get; set; }
        public bool IsConnected { get; set; }
        public int Port { get; set; } 
        public string Host { get; set; }


        public virtual ICollection<MqttSubscriptionModel> SubscriptionList { get; set; } = new List<MqttSubscriptionModel>();
    }
}
