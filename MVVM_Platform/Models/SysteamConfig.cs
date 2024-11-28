using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SysteamConfig
    {


        public SysteamConfig Load()
        {
            if (!File.Exists(""))
            {
                return null;
            }
            else
            {
              return  JsonConvert.DeserializeObject<SysteamConfig>("");
            }
        }

        public void Save()
        {
            if (!File.Exists(""))
            {
                File.Create("").Close();
            }
            string data = JsonConvert.SerializeObject(this);
            System.IO.File.WriteAllText("SysteamConfig.json", data);
        }
    }
}
