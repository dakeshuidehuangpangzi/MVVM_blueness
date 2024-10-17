using Microsoft.Extensions.DependencyInjection;
using PlatformViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Platform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            if (new LoginView().ShowDialog()!=true)
                Application.Current.Shutdown();


            InitializeComponent();
            this.DataContext = App.Current.Services.GetRequiredService<MainViewModel>();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Hidden_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
