using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IBLL;
using Models;
using NLog;
using Platform.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformViewModel
{
    public partial class SettingViewModel : ObservableObject
    {
        readonly Logger log=LogManager.GetCurrentClassLogger();
        [ObservableProperty]
        BaseConfig config=new();
        


        //ILoginBLL _loginBLL;

        public SettingViewModel()
        {
            this.config =GlobalConfig.Instance.BaseConfig;
        }


        [RelayCommand]
        public void SaveConfig()
        {
            GlobalConfig.Instance.Save(PathConfig.SystemConfig);
            log.Info("参数保存成功");
        }
    }
}
