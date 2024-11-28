using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PlatformViewModel.ShowDiglog
{
    public partial class AddSubscriptionDialogViewModel: ObservableObject
    {
        MQTTClient MQTT;
        [ObservableProperty]
        MqttSubscriptionModel model=new();

        #region 方法
        public AddSubscriptionDialogViewModel(MQTTClient client )
        {
            MQTT = client??new();
        }

        [RelayCommand]
        public void ADD(object parmer)
        {
            var pa = parmer as MqttSubscriptionModel;
            if (!MQTT.model.listTopic.Any(x => x.Topic == pa.Topic))
            {
                MQTT.model.listTopic.Add(pa);
            }
        }
        #endregion


        #region 属性

        #endregion
    }
}
