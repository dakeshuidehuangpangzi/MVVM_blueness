using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;
using Common;
using System.Windows.Media.Media3D;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Models;
using CommunicationComponent;
using Platform.Extensions;
using ConfigurationServices;
namespace PlatformViewModel
{
    public partial class MQTTTestViewModel: ObservableRecipient, IRecipient<string>
    {
        //MQTT集合对象
        [ObservableProperty]
        private ObservableCollection<MQTTClient> clients=new();
        private ConfigurationService config;
        //[ObservableProperty]
        //List<string> istClient;
        [ObservableProperty]
        object _viewContent;
        public MQTTTestViewModel(IConfigurationService configuration)
        {
            IsActive = true;
            config = (ConfigurationService)configuration;
            //全局Clients参数添加
            config.Clients.ForEach(x => Clients.Add(new MQTTClient() { Model =x }));
        }
        [RelayCommand]
        public void AddSubscribe(object clent)
        {
            //ActionManager.ExecuteAndResult("AddSubscription", clent);

            //clent.
            Type type = Assembly.Load("MVVM_Platform")
    .GetType("MVVM_Platform." + "MqttNewConnectview")!;
            ViewContent = Activator.CreateInstance(type)!;
        }
        [RelayCommand]
        public void PublishMessage()
        {

        }
        [RelayCommand]
        public void SaveConfig()
        {
            config.SaveConfigs();
        }
        [RelayCommand]
        public void AddClient(MQTTClient client)
        {
            clients.Add(client);
        }
        [RelayCommand]
        public void OpenView(object obj)
        {
            //需要创建一个DLL里面的绝对路径，不然会找不到具体的位置，容易报错
            Type type = Assembly.Load("MVVM_Platform")
                .GetType("MVVM_Platform." + "MQTTSendAndConfigview")!;
            ViewContent = Activator.CreateInstance(type,obj)!;
        }

        //public void Receive(PropertyChangedMessage<string> message)
        //{

        //}

        public void Receive(string message)
        {
            var res =  message.Split(';');
            if (res.Length!=0||res!=null)
            {       
                //返回打开界面

                if (res.Any(x => x.Contains(value: "OK")))
                {
                    Clients = new ();
                    config.Clients.ForEach(x =>  Clients.Add(new MQTTClient() { Model = x }));
                    OpenView(config.Clients.FirstOrDefault());
                }
                if (res.Any(x=>x.Contains("Return")))
                {
                    OpenView(config.Clients.FirstOrDefault());
                }
            }
        }
    }
}
