using BLL;
using DAL;
using IBLL;
using IDAL;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using PlatformViewModel.ShowDiglog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlatformViewModel
{
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
            services.AddSingleton<SettingViewModel>();
            services.AddTransient<TrendViewModel>();
            services.AddTransient<ILoginBLL, LoginBLL>();
            services.AddTransient<ILoginDal, LoginDal>();
            services.AddSingleton<MQTTTestViewModel>();
            services.AddScoped<MQTTSendAndConfigviewModel>();
            services.AddScoped<AddSubscriptionDialogViewModel>();

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
            services.AddSingleton<SettingViewModel>();
            services.AddTransient<TrendViewModel>();
            services.AddTransient<ILoginBLL, LoginBLL>();
            services.AddTransient<ILoginDal, LoginDal>();
            services.AddSingleton<MQTTTestViewModel>();
            services.AddScoped<MQTTSendAndConfigviewModel>();
            services.AddScoped<AddSubscriptionDialogViewModel>();

            
        }


        public ViewModelLocatorBuilder Build() { return  this; }
        public ViewModelLocatorBuilder WithLoginModel(string fileName) { return this; }

    }
    #endregion

}
