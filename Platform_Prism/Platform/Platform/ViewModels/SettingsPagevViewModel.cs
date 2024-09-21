using Platform.Models;
using PlcPlatform;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Platform.ViewModels
{
    public class SettingsPageViewModel : PageBase
    {
        IRegionManager _regionManager;
        IDialogService _dialogService;
        public SettingsPageViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;
            this.TitleName = "SettingsPage";
            Property.Add(new Parameter()
            {
                AddressName = "XA",
                DataType = typeof(string),
                MachineName = "System",
                MachineType = MachineType.Mitsubishi,
                Name = "Name",
            });

            //var array = Enum.GetValues(typeof(MitsubishiEnum));
            //foreach (var item in array) 
            //{
            //    MyProperty.Add(item.ToString());
            //}

            AddPlaformCommand = new DelegateCommand(AddPlaform);
            AddConfigCommand = new DelegateCommand<object>(AddConfig);
        }
        public ObservableCollection<CommunicationUnit> ListUnit { get; set; } = new ObservableCollection<CommunicationUnit>();

        public ObservableCollection<string> MyProperty { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<Parameter> Property { get; set; } = new ObservableCollection<Parameter>();

        public ICommand AddPlaformCommand { get; set; }
        public ICommand AddConfigCommand { get; set; }
        public ICommand DeleteConfigCommand { get; set; }

        private void AddPlaform()
        {
            DialogParameters par = new DialogParameters();
             
            par.Add("Unit", ListUnit);
            //弹出对话框
            _dialogService.ShowDialog("MitsubishiConfigDialog", par,
                new Action<IDialogResult>(result => {
                    if (result.Result == ButtonResult.OK && result!=null)
                    {
                        //获取参数值
                        var url = result.Parameters.GetValue<ObservableCollection<CommunicationUnit>>("Unit");
                        ListUnit = url;
                    }
                }));
        }

        private void AddConfig(object Parameter)
        {
            DialogParameters par = new DialogParameters();

            par.Add("Unit", Parameter);
            //弹出对话框
            _dialogService.ShowDialog("MeterConfigDialog", par,
                new Action<IDialogResult>(result =>{
                    if (result.Result == ButtonResult.OK && result != null)
                    {
                        //获取参数值
                        //var url = result.Parameters.GetValue<CommunicationUnit>("Unit");
                        //var che = ListUnit.ToList().FindIndex(x => x.Device == url.Device);
                        //if (che != null)
                        //{
                        //    ListUnit[che] = url;
                        //}
                    }
                }));
        }

        private void DeleteConfig()
        {
            var view = _regionManager.Regions["ContentRegion"].Views.FirstOrDefault(x => x.GetType().Name == "DeleteConfigView");
            if (view == null)
            {
                _regionManager.RequestNavigate("ContentRegion", "DeleteConfigView");
            }
            else
            {
                _regionManager.Regions["ContentRegion"].Activate(view);
            }
        }


    }
}
