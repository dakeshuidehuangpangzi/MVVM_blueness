using Models;
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
        public  readonly NLog.Logger Logger ;
        public App()
        {
            Logger = NLog.LogManager.GetCurrentClassLogger();
            GlobalConfig.Instance.Init();
            Services = ConfigureAllServices();
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
            Service.AddPlatformViewModelExtensions()
                    .Build()
                    .WithLoginModel("LoginModel");
            Logger.Info("ConfigureAllServices");
            //注册所有的依赖对象
            return Service.BuildServiceProvider();
        }


        public IServiceProvider Services { get; }
        public new static App Current => (App)Application.Current;

    }
}
