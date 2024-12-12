using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using SystemConfig;

namespace Models
{
    public partial class GlobalConfig: ObservableObject
    {
        #region 单例
        public static readonly object mutx = new();
        private static GlobalConfig instance;

        public static GlobalConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (mutx)
                    {
                        instance = new();
                    }
                }
                return instance;
            }
        }
        #endregion

        [ObservableProperty]
         BaseConfig baseConfig= new();

        [ObservableProperty]
        List<MQTTClientModel> clients = new();

        public void Init()
        {
            Load(PathConfig.SystemConfig);
        }

        public void Load(string path)
        {
            if (!File.Exists(path))//设置路径
            {
                instance = new();
                Save(PathConfig.SystemConfig);
            }
            else
            {
                instance= JsonConvert.DeserializeObject<GlobalConfig>(FileControls.ReadFile(path));
            }
        }

        public  void Save(string path)
        { 
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            string data = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, data);
        }
    }
}
