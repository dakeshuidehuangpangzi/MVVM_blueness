using Platform.ViewModels.Dialog;
using Platform.Views;
using Platform.Views.Dialog;
using PlcPlatform.Realize.Can;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wireless;

namespace Platform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return base.CreateModuleCatalog();
        }

        protected override Window CreateShell()
        {
            //Bluetooth bluetooth = new Bluetooth();
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterDialogWindow<DialogWindow>();//注册主弹窗窗体

            containerRegistry.RegisterDialog<MitsubishiConfigDialog>();
            containerRegistry.RegisterDialog<MeterConfigDialog>();




            containerRegistry.RegisterForNavigation<AlarmPage>();
            containerRegistry.RegisterForNavigation<HistoryPage>();
            containerRegistry.RegisterForNavigation<MonitorPage>();
            containerRegistry.RegisterForNavigation<ReportPage>();
            containerRegistry.RegisterForNavigation<SettingsPage>();
            containerRegistry.RegisterForNavigation<TrendPage>();

        }
    }
}
