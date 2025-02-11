
using Platform.Extensions.Interfaces;

namespace MvvmDialoging
{
    public static class DialogServiceExtensions
    {
        /// <summary>
        /// 单例
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureDialogServiceSingleton(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            return services.AddSingleton<IDialogService, DialogService>();
        }

        public static IServiceCollection ConfigureDialogServiceTransient(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            return services.AddTransient<IDialogService, DialogService>();
        }
        /// <summary>
        /// 获取弹窗业务类
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static DialogService GetDialogService(this IServiceProvider service) => (DialogService)service.GetRequiredService<IDialogService>();

    }
}
