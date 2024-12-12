using System;
using System.Collections.Generic;
using System.Text;

namespace SystemConfig
{
    public class PathConfig
    {
        public static string FolderSysConfig = AppDomain.CurrentDomain.BaseDirectory + @"Configs\";

        public static string SystemConfig = FolderSysConfig + "SystemConfig.json";

    }
}
