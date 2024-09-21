using Platform.Models;
using PlcPlatform;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platform.ViewModels.Dialog
{
    public class MitsubishiConfigDialogViewModel : BindableBase,IDialogAware
    {
        #region 实现接口
        public string Title => "三菱参数配置";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            var par= parameters.GetValue<ObservableCollection<CommunicationUnit>>("Unit");
            if (par!= null)
            {
                ListUnit = par;
            }
        }
        #endregion

        public ObservableCollection<string> Type { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> DisPoseType { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Parity { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> StopBits { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> baudRate { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> dataBits { get; set; } = new ObservableCollection<string>();


        public ObservableCollection<CommunicationUnit> ListUnit { get; set; } = new ObservableCollection<CommunicationUnit>();
        public CommunicationUnit Unit { get; set; } = new CommunicationUnit();

        public ICommand TextCommand { get; set; }


        public MitsubishiConfigDialogViewModel()
        {
            #region 绑定数据
            Type.Add("Mitsubishi");
            Type.Add("OMRON");
            Type.Add("Modebus");
            Type.Add("MQTT");
            Type.Add("Siemens");
            Type.Add("Can");


            DisPoseType.Add("TCP/IP");
            DisPoseType.Add("UDP/IP");
            DisPoseType.Add("Serial");


            Parity.Add("None");
            Parity.Add("Odd");
            Parity.Add("Even");

            StopBits.Add("One");
            StopBits.Add("One");
            StopBits.Add("Two");

            baudRate.Add("9600");
            baudRate.Add("19200");
            baudRate.Add("38400");
            baudRate.Add("57600");
            baudRate.Add("115200");

            dataBits.Add("8");
            dataBits.Add("7");
            dataBits.Add("6");
            #endregion
            TextCommand = new DelegateCommand(get);
        }

        private void get()
        {
            var check=ListUnit.FirstOrDefault(x => (x.Address == Unit.Address && x.Port == Unit.Port && x.Type != "Serial") ||
                                            ( x.Serial == Unit.Serial && x.Type== "Serial") && x.DeviceName != Unit.DeviceName);
            if (check == null)
            {
                MitsubishiParameter parameter = (MitsubishiParameter)CheckParameter.Check(new Parameter()
                {   
                    AddressName = "Y1",
                    MachineType=  MachineType.Mitsubishi,
                    MachineName = "test",
                });
                Unit.Meter.Add(parameter);
                ListUnit.Add(Unit);
                DialogParameters par = new DialogParameters();
                par.Add("Unit", ListUnit);
                RequestClose.Invoke(new DialogResult(ButtonResult.OK, par));
            }
            else
            {
                RequestClose.Invoke(new DialogResult(ButtonResult.Cancel, null));
            }

        }
    }
}
