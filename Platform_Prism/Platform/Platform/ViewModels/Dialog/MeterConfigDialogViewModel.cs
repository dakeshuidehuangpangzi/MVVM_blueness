using Platform.Models;
using PlcPlatform;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platform.ViewModels.Dialog
{
    public class MeterConfigDialogViewModel : BindableBase, IDialogAware
    {
        #region 实现接口
        public string Title => "读取信息配置";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            var par = parameters.GetValue<CommunicationUnit>("Unit");
            if (par != null)
            {
                Parameters = par;
            }
        }
        #endregion
        public CommunicationUnit Parameters { get; set; } = new CommunicationUnit();
        


        private Parameter param=new Parameter();
        public Parameter Param
        {
            get { return param; }
            set { SetProperty(ref param, value); }
        }
        public ICommand TextCommand { get; set; }
        public ICommand AddCommand { get; set; }

        public MeterConfigDialogViewModel( )
        {
            TextCommand = new DelegateCommand(Get);
            AddCommand = new DelegateCommand(Add);
        }

        private void Get()
        {
            //var check = ListUnit.FirstOrDefault(x => (x.Address == Unit.Address && x.Port == Unit.Port && x.Type != "Serial") ||
            //                                (x.Serial == Unit.Serial && x.Type == "Serial") && x.DeviceName != Unit.DeviceName);
            //if (check == null)
            //{
                DialogParameters par = new DialogParameters();
                par.Add("Unit", Parameters);
                RequestClose.Invoke(new DialogResult(ButtonResult.OK, par));
            //}
            //else
            //{
            //    RequestClose.Invoke(new DialogResult(ButtonResult.Cancel, null));
            //}
        }

        private void Add()
        {
            if (Parameters.Meter.FirstOrDefault(x => x.AddressName != Param.AddressName)!= null)
            {
                Parameters.Meter.Add(Param);
            }
            param = new Parameter();
        }

    }
}
