using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Models;
using MVVM_Platform.ViewModels;
using Platform.Extensions.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MVVM_Platform
{
    public partial class MQTTSendAndConfigviewModel : ObservableRecipient, IRecipient<string>
    {
        #region 属性
        [ObservableProperty]
        MQTTClient client;
        [ObservableProperty]
        bool isConnected =false;
        [ObservableProperty]
        int accept=0;
        [ObservableProperty]
        string errMessage = "";
        //绑定事件委托
        /// <summary>
        /// 接收信息
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<string> receiveMessage=new();

        [ObservableProperty]
        object user;
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
        public void Connect( object obj)
        {
            if (User is null)
            {
                User = obj;
            }
            VisualStateManager.GoToElementState(obj as UserControl, "NormalSuccess", true);
            try
            {
                Client.ConnectAsync();
                Client.Connected += Client_Connected;
                Client.OneErrmessage += Client_OneErrmessage;
            }
            catch (Exception ex) 
            {

                VisualStateManager.GoToElementState(obj as UserControl, "SaveFailedShow", true);
            }
        }

        private void Client_OneErrmessage(object? sender, CommunicationComponent.ErrMessageArg e)
        {
            ErrMessage = e.Errmessage;
            VisualStateManager.GoToElementState(User as UserControl, "SaveFailedShow", true);
        }

        [RelayCommand]
        public void Delate(object parm)
        {
            if (parm is MqttSubscriptionModel)
            {
                Client.Model.listTopic.Remove(Client.Model.listTopic.FirstOrDefault(x => x.Topic == ((MqttSubscriptionModel)parm).Topic));
            }
        }
        private void Client_Connected(object? sender, bool e)
        {
            IsConnected =e;
            Application.Current.Dispatcher.Invoke(() => {
                if (Client.IsConnect) VisualStateManager.GoToElementState(user as UserControl, "SaveSuccess", true);
            });

        }

        [RelayCommand]
        public void AddSubscribe()
        {
            if (App.Current.ShowDialog(new AddSubscriptionDialogViewModel(Client) { }) == EDialogResult.OK)
            {
                var topic = Client.Model.listTopic.LastOrDefault();
                if (topic != null) Client.Subscribe(topic.Topic);
            }
            //if (ActionManager.ExecuteAndResult<object>("AddSubscription", new AddSubscriptionDialogViewModel(Client) { }))
            //{
            //   var topic=  Client.Model.listTopic.LastOrDefault();
            //    if (topic!=null) Client.Subscribe(topic.Topic);
            //} 
        }
        [RelayCommand]
        public void SendMessage(object obj)
        {
            VisualStateManager.GoToElementState(obj as UserControl, "NormalSuccess", true);
            if (!IsConnected)
            {
                VisualStateManager.GoToElementState(obj as UserControl, "SaveFailedShow", true);
            }
        }
        [RelayCommand]
        public void CloseSaveFailed(object obj)
        {
            VisualStateManager.GoToElementState(obj as UserControl, "SaveFailedClose", true);
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
