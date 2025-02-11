using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Models;
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
using System.Windows.Shapes;

namespace MVVM_Platform.Views
{
    /// <summary>
    /// AddSubscriptionDialog.xaml 的交互逻辑
    /// </summary>
    public partial class AddSubscriptionDialogView : Window
    {

        public AddSubscriptionDialogView()
        {
            InitializeComponent();
            //this.DataContext = App.Current.Services.GetRequiredService<AddSubscriptionDialogViewModel>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WeakReferenceMessenger.Default.Register<CloseDialogWindowMessage>(this, (_, m) =>
            {
                if (m.Sender?.Target == this.DataContext)
                {
                    this.DialogResult = true;
                    this.Close();
                }
                if (m.Close == true)
                {
                    this.DialogResult = false;
                    this.Close();
                }
            });

        }
    }
}
