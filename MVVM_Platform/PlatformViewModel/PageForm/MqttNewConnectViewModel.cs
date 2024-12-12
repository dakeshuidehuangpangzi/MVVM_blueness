using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformViewModel
{
    public partial class MqttNewConnectViewModel : ObservableRecipient
    {
        [ObservableProperty]
        MQTTClientModel model = new();


        public MqttNewConnectViewModel()
        {
             Model = new();
        }

        [RelayCommand]
        public void Save()
        {
            if (!GlobalConfig.Instance.Clients.Contains(model))
            {
                GlobalConfig.Instance.Clients.Add(model);
            }
            OnReceiveMessageChanged();

        }
        [RelayCommand]
        public void Return()
        {
            WeakReferenceMessenger.Default.Send("Close;Return");//属性变化的时候进行消息通知
        }
        private void OnReceiveMessageChanged()
        {
            WeakReferenceMessenger.Default.Send("Close;AddOK");//属性变化的时候进行消息通知
        }



    }
}
