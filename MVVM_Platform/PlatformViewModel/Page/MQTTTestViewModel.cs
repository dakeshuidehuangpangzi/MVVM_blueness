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
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
            Clients.Add(new()
            {
                ClientID = "Test1",
                CleanStart = false,
                KeepAlive = 30,
                Name = "测试添加"
            });
        }

        [RelayCommand]
        public void AddSubscribe(MQTTClient clent)
        {
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

        }
    }
}
