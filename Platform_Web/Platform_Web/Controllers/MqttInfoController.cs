using IServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Platform_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MqttInfoController : ControllerBase
    {
        IMqttService _mqttService;
        public MqttInfoController(IMqttService mqttService)
        {
            _mqttService = mqttService;
        }
        [HttpGet]
        public bool Add(MqttList mqtt)
        {
            return true;
        }
    }
}
