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
namespace PlatformViewModel
{
    public partial class MQTTTestViewModel: ObservableObject
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
            Clients.Add(new()
            {
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive=30,
                Name="测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test2",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test3",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test4",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test5",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test6",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test7",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
        }
        [RelayCommand]
        public void AddSubscribe(object clent)
        {
            ActionManager.ExecuteAndResult("AddSubscription", clent);
            
            //clent.
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
    }
}
