using PlatformViewModel;
using PlatformViewModel.ShowDiglog;
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
using System.Windows.Shapes;

namespace MVVM_Platform
{
    /// <summary>
    /// AddSubscriptionDialog.xaml 的交互逻辑
    /// </summary>
    public partial class AddSubscriptionDialog : Window
    {

        public AddSubscriptionDialog()
        {
            InitializeComponent();
            //this.DataContext = App.Current.Services.GetRequiredService<AddSubscriptionDialogViewModel>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
