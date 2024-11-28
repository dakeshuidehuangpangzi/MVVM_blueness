using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServer
{
    public interface IMqttService:IBaseService
    {
        public bool ADDMqttSite(MqttList info);
    }
}
