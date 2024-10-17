using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationComponent;
using CommunityToolkit.Mvvm.Input;
namespace PlatformViewModel
{
    public partial class MQTTTestViewModel: ObservableObject
    {
        //MQTT集合对象
        [ObservableProperty]
        private List<MQTTClient> clients;
        //[ObservableProperty]
        //List<string> istClient;
        public MQTTTestViewModel()
        {
                
        }

        [RelayCommand]
        public void AddSubscribe(MQTTClient clent)
        {
            //clent.
        }

    }
}
