using PlcPlatform;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Models
{
    public class CommunicationUnit : BindableBase
    {

        private string deviceId;

        public string Device
        {
            get { return deviceId; }
            set { SetProperty(ref deviceId, value); }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }
        private string address;

        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }
        private string port;

        public string Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }
        private string deviceName;

        public string DeviceName
        {
            get { return deviceName; }
            set { SetProperty(ref deviceName, value); }
        }
        private int timeout;

        public int Timeout
        {
            get { return timeout; }
            set { SetProperty(ref timeout, value); }
        }
        private string serial;

        public string Serial
        {
            get { return serial; }
            set { SetProperty(ref serial, value); }
        }
        private string baudRate;

        public string BaudRate
        {
            get { return baudRate; }
            set { SetProperty(ref baudRate, value); }
        }
        private string dataBits;

        public string DataBits
        {
            get { return dataBits; }
            set { SetProperty(ref dataBits, value); }
        }
        private string parity;

        public string Parity
        {
            get { return parity; }
            set { SetProperty(ref parity, value); }
        }
        private ObservableCollection<Parameter> meter = new ObservableCollection<Parameter>();
        public ObservableCollection<Parameter> Meter
        {
            get { return meter; }
            set { SetProperty(ref meter, value); }
        }


    }
}
