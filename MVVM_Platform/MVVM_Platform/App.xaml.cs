using ConfigurationServices;
using Models;
using MVVM_Platform.ViewModels;
using MvvmDialoging;
using NLog;
using Platform.Extensions.Enum;
using PlatformViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MVVM_Platform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public  readonly Logger Logger ;
        public App()
        {
            Logger = LogManager.GetCurrentClassLogger();
            GlobalConfig.Instance.Init();
            Services = ConfigureAllServices();
            Services.GetConfiguration().LoadConfigs();
        }

        public IServiceProvider ConfigureAllServices()
        {
            //获取其他类库的注册
            IServiceCollection Service = new ServiceCollection();
            //注册主线程调度
            Service.AddSingleton(typeof(Dispatcher), obj => Application.Current.Dispatcher);
            //dateConText注册方式   在创建的时候就赋予进去
            //Service.AddSingleton(sp => new MainView() { DataContext = sp.GetService<MainViewModel>() });
            Service.AddPlatformViewModelServices();//其他类库就在这里注册
            //Service.AddSingleton<Logger>();
            Service.AddPlatformViewModelExtensions()
                    .Build()
                    .WithLoginModel("LoginModel");
            Service.AddTransient<AddSubscriptionDialogViewModel>();
            Service.AddScoped<MQTTSendAndConfigviewModel>();
            Service.ConfigureDialogServiceSingleton();
            Service.ConfigurationServiceSingleton();
            Logger.Info("ConfigureAllServices");
            //注册所有的依赖对象
            return Service.BuildServiceProvider();
        }


        public IServiceProvider Services { get; }
        public new static App Current => (App)Application.Current;

        public EDialogResult ShowDialog(ViewModelBaseDialog viewModel)
        {
            return Services.GetDialogService().ShowDialog(viewModel, Services.GetService<MainViewModel>());
        }
    }
}
