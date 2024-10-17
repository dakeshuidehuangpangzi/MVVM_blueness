using BLL;
using DAL;
using IBLL;
using IDAL;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlatformViewModel
{
    public class ViewModelLocator
    {
      
        public  static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<LoginModel>();
            //services.AddKeyedTransient<LoginModel>("123");
            services.AddTransient<MainViewModel>();
            services.AddTransient<AlarmViewModel>();
            services.AddTransient<HistoryViewModel>();
            services.AddTransient<ManualOperationViewModel>();
            services.AddTransient<MonitorViewModel>();
            services.AddTransient<SettingViewModel>();
            services.AddTransient<TrendViewModel>();
            services.AddTransient<ILoginBLL,LoginBLL>();

            services.AddTransient<ILoginDal, LoginDal>();

            return services;
        }

    }

    public static class PlatformViewModelServiceCollectionExtension
    {
        public static void AddPlatformViewModelServices(this IServiceCollection services)
        {
            services.AddTransient<LoginModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<AlarmViewModel>();
            services.AddTransient<HistoryViewModel>();
            services.AddTransient<ManualOperationViewModel>();
            services.AddTransient<MonitorViewModel>();
            services.AddTransient<SettingViewModel>();
            services.AddTransient<TrendViewModel>();
            services.AddTransient<ILoginBLL, LoginBLL>();
            services.AddTransient<ILoginDal, LoginDal>();
        }

    }



    #region 建造者模式
    public static class ViewModelLocatorExtensions
    {
        public static ViewModelLocatorBuilder AddPlatformViewModelExtensions(this IServiceCollection services)
        {
            return new ViewModelLocatorBuilder(services);
        }

    }

    public class ViewModelLocatorBuilder
    {
        public ViewModelLocatorBuilder(IServiceCollection services)
        {
            services.AddTransient<LoginModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<AlarmViewModel>();
            services.AddTransient<HistoryViewModel>();
            services.AddTransient<ManualOperationViewModel>();
            services.AddTransient<MonitorViewModel>();
            services.AddTransient<SettingViewModel>();
            services.AddTransient<TrendViewModel>();
            services.AddTransient<ILoginBLL, LoginBLL>();
            services.AddTransient<ILoginDal, LoginDal>();
        }


        public ViewModelLocatorBuilder Build() { return  this; }
        public ViewModelLocatorBuilder WithLoginModel(string fileName) { return this; }

    }
    #endregion

}
