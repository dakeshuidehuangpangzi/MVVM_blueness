using IDAL;
using IServer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MqttService : BaseService, IMqttService
    {
        public MqttService(IDbContext dbConfig) : base(dbConfig)
        {
        }

        public bool ADDMqttSite(MqttList info)
        {
            this.Insert<MqttList>(info);
            return true;
        }
    }
}
