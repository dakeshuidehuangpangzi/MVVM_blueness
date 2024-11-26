using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using PlatformViewModel.ShowDiglog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PlatformViewModel
{
    public partial class MQTTSendAndConfigviewModel : ObservableRecipient, IRecipient<string>
    {
        #region 属性
        [ObservableProperty]
        MQTTClient client;
        [ObservableProperty]
        bool isConnected;


        //绑定事件委托
        /// <summary>
        /// 接收信息
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> receiveMessage=new();

        #endregion


        #region 事件接收
        public MQTTSendAndConfigviewModel()
        {
        }

        private void Client_MessageReceived(object? sender, CommunicationComponent.MessageReceivedArg e)
        {
            if (e!=null)
            {
                //反序列输出
                string message = e.Payload + e.Topic;
                ReceiveMessage.Add(message);
               // Client.Publish(e.Topic, Client.ClientID+"--->"+ e.Payload);
            }
           
        }

        #endregion

        #region 方法

        [RelayCommand]
        public void Connect()
        {
            Client.ConnectAsync();
            Client.Connected += Client_Connected;
        }

        private void Client_Connected(object? sender, bool e)
        {
            isConnected = e;
        }

        [RelayCommand]
        public void AddSubscribe()
        {
            ActionManager.ExecuteAndResult("AddSubscription", new AddSubscriptionDialogViewModel(Client) {  });
            //Client.Subscribe("xunz");

            //Client.MessageReceived += Client_MessageReceived;

            //clent.
        }

        partial void OnReceiveMessageChanged(ObservableCollection<string> value)
        {
            WeakReferenceMessenger.Default.Send(value);//属性变化的时候进行消息通知
        }

        public void Receive(string message)
        {
            receiveMessage.Add(message);
            while (receiveMessage.Count>100)
            {
                receiveMessage.Remove(receiveMessage.First());
            }
        }
        #endregion
    }
}
