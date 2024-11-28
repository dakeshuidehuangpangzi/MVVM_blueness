using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemConfig;

namespace Models
{
    public partial class TestConfig: ObservableObject
    {
        [ObservableProperty]
        string plcIp = "127.16.10.1";

        [ObservableProperty]
        int port = 1883;

        public TestConfig Load()
        {
            if (!File.Exists(PathConfig.SystemConfig))//设置路径
            {
                return null;
            }
            else
            {
              return JsonConvert.DeserializeObject<TestConfig>(FileControls.ReadFile(PathConfig.SystemConfig));
            }
        }

        public void Save()
        {
            if (!File.Exists(PathConfig.SystemConfig))
            {
                File.Create(PathConfig.SystemConfig).Close();
            }
            string data = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText(PathConfig.SystemConfig, data);
        }
    }
}
