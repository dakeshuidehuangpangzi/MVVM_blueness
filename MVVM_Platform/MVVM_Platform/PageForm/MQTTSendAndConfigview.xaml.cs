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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM_Platform
{
    /// <summary>
    /// MQTTSendAndConfigview.xaml 的交互逻辑
    /// </summary>
    public partial class MQTTSendAndConfigview : UserControl
    {
        MQTTClient mQTT = null;
        public MQTTSendAndConfigview(object abc)
        {
            InitializeComponent();
            mQTT = abc as MQTTClient;
            var Context = App.Current.Services.GetService<MQTTSendAndConfigviewModel>();
            if (Context != null)
            {
                Context.Client = mQTT;
            }
            this.DataContext = Context;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            //ListTopic.ItemsSource = ((MQTTSendAndConfigviewModel)DataContext).Client.Model.listTopic;

        }
    }
}
