using PlatformViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM_Platform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ViewModelLocator.ConfigureServices();
        }
        public IServiceProvider Services { get; }
        public new static App Current => (App)Application.Current;

    }
}
