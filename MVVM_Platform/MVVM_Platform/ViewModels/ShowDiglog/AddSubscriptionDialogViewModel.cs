

using MvvmDialoging;
using Platform.Extensions.Enum;
using System.Windows.Input;

namespace MVVM_Platform.ViewModels
{
    public partial class AddSubscriptionDialogViewModel: ViewModelBaseDialog
    {
        MQTTClient MQTT;
        [ObservableProperty]
        MqttSubscriptionModel model=new();

        [ObservableProperty]
        ObservableCollection<MqttQualityOfServiceLevel> enumlist = new();


        #region 方法
        public AddSubscriptionDialogViewModel(MQTTClient client )
        {
            MQTT = client??new();
            foreach (MqttQualityOfServiceLevel item in Enum.GetValues(typeof(MqttQualityOfServiceLevel)))
            {
                enumlist.Add(item);
            }

           // WeakReferenceMessenger.Default.Register<RequestMessage<bool>>(this, (_, m) => m.Reply(SaveData()));
        }

        [RelayCommand]
        public void ADD(object parmer)
        {
            var pa = parmer as MqttSubscriptionModel;
            if (!MQTT.Model.listTopic.Any(x => x.Topic == pa.Topic))
            {
                MQTT.Model.listTopic.Add(pa);
            }
            OkBtn();
            //CloseWindow(true);
        }
        public bool SaveData()
        {
            return false;
        }
        [RelayCommand]
        public void CloseWindow(object o)
        {
            WeakReferenceMessenger.Default.Send(new CloseDialogWindowMessage { Sender = o == null ? null: new WeakReference(this), Close = o == null ? true : false });
        }
        [RelayCommand]
        public void Close(Window o)
        {
            o.DialogResult = false;
        }

        [RelayCommand]
        void DragMoveBtn(object e)
        {
            if (e is MouseButtonEventArgs args)
            {
                if (args.ChangedButton == MouseButton.Left) App.Current.Services.GetDialogService()?.OperationDialog(this, EOperationDialog.DragMove);
            }
        }
        [RelayCommand]
        void OkBtn() => CloseDialog(EDialogResult.OK);

        [RelayCommand]
        void CancelBtn() => CloseDialog(EDialogResult.Cancel);
        [RelayCommand]
        void RetryBtn() => CloseDialog(EDialogResult.Retry);

        [RelayCommand]
        void IgnoreBtn() => CloseDialog(EDialogResult.Ignore);

        [RelayCommand]
        void ExitBtn() => CloseDialog(EDialogResult.Exit);

        void CloseDialog(EDialogResult result = EDialogResult.OK)
        {
            DialogResult = result;
            App.Current.Services.GetDialogService()?.CloseDialog(this);
        }
        #endregion


        #region 属性
        [ObservableProperty]
        bool _isOkVisible;
        [ObservableProperty]
        bool _isCancelVisible;
        [ObservableProperty]
        bool _isIgnoreVisible;
        [ObservableProperty]
        bool _isRetryVisible;
        [ObservableProperty]
        bool _isExitVisible;
        #endregion
    }
}
