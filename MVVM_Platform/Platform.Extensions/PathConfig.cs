using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Extensions
{
    public class PathConfig
    {
        public static string FolderSysConfig = AppDomain.CurrentDomain.BaseDirectory + @"Configs\";

        public static string SystemConfig = FolderSysConfig + "SystemConfig.json";

    }
}
