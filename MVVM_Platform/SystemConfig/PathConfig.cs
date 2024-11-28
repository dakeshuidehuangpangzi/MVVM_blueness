using System;
using System.Collections.Generic;
using System.Text;

namespace SystemConfig
{
    public class PathConfig
    {
        public static string FolderSysConfig = AppDomain.CurrentDomain.BaseDirectory + @"Config\";

        public static string SystemConfig = FolderSysConfig + "SystemConfig.json";

    }
}
