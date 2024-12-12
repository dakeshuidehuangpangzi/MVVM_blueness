using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Models;
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
            WeakReferenceMessenger.Default.Register<CloseDialogWindowMessage>(this, (_, m) =>
            {
                if (m.Sender?.Target == this.DataContext)
                {
                    this.Close();
                }
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //var response = WeakReferenceMessenger.Default.Send(new RequestMessage<bool>());
            //if (response.Response) this.Close();
        }
    }
}
