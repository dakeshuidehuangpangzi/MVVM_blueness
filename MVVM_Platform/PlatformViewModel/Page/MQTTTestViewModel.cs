using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationComponent;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;
using Common;
using System.Windows.Media.Media3D;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Models;
namespace PlatformViewModel
{
    public partial class MQTTTestViewModel: ObservableRecipient, IRecipient<PropertyChangedMessage<string>>
    {
        //MQTT集合对象
        [ObservableProperty]
        private ObservableCollection<MQTTClient> clients=new();
        //[ObservableProperty]
        //List<string> istClient;
        [ObservableProperty]
        object _viewContent;
        public MQTTTestViewModel()
        {
            IsActive = true;
            //全局Clients参数添加
            GlobalConfig.Instance.Clients.ForEach(x => Clients.Add(new MQTTClient() { model =x }));
        }
        [RelayCommand]
        public void AddSubscribe(object clent)
        {
            //ActionManager.ExecuteAndResult("AddSubscription", clent);

            //clent.
            Type type = Assembly.Load("MVVM_Platform")
    .GetType("MVVM_Platform." + "MQTTSendAndConfigview")!;
            ViewContent = Activator.CreateInstance(type)!;
        }
        [RelayCommand]
        public void PublishMessage()
        {

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

        public void Receive(PropertyChangedMessage<string> message)
        {
            throw new NotImplementedException();
        }
    }
}
