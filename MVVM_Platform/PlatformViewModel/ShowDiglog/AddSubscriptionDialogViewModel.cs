using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Models;
using MQTTnet.Protocol;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [ObservableProperty]
        ObservableCollection<MqttQualityOfServiceLevel> enumlist = new();


        #region 方法
        public AddSubscriptionDialogViewModel(MQTTClient client )
        {
            MQTT = client??new();


            foreach (MqttQualityOfServiceLevel item in Enum.GetValues(typeof(MqttQualityOfServiceLevel)))
            {
                enumlist.Add(item);
            }

           // WeakReferenceMessenger.Default.Register<RequestMessage<bool>>(this, (_, m) => m.Reply(SaveData()));
        }

        [RelayCommand]
        public void ADD(object parmer)
        {
            var pa = parmer as MqttSubscriptionModel;
            if (!MQTT.Model.listTopic.Any(x => x.Topic == pa.Topic))
            {
                MQTT.Model.listTopic.Add(pa);
            }
            CloseWindow();
        }
        public bool SaveData()
        {
            return false;
        }
        [RelayCommand]
        public void CloseWindow()
        {
            //if (SaveData())
            //{
                WeakReferenceMessenger.Default.Send(new CloseDialogWindowMessage { Sender = new WeakReference(this) });
            //}
        }
        #endregion


        #region 属性

        #endregion
    }
}
