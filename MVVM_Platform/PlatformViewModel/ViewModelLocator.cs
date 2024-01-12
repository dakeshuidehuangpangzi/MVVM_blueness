using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PlatformViewModel
{
    public class ViewModelLocator
    {
      

        public  static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<LoginModel>();

            return services.BuildServiceProvider();
        }

    }
}
