using CommunicationComponent;
using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using MvvmDialoging;
using NLog;
using Platform.Extensions.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_Platform.ViewModels
{
    public partial class ShowDialogViewModel : ViewModelBaseDialog
    {
        public ShowDialogViewModel(EloggerLevel level, string message, string title, EShowDialogBtnState btnState = EShowDialogBtnState.OkCancel)
        {
            Level = level;
            Message = message;
            Title = title;
            if (string.IsNullOrEmpty(title)) Title = "提示";
            ButtonState = btnState;
            switch (ButtonState)
            {
                case EShowDialogBtnState.OK:
                    IsOkVisible = true;
                    break;
                case EShowDialogBtnState.OkCancel:
                    IsCancelVisible = IsOkVisible = true;
                    break;
                case EShowDialogBtnState.IgnoreRetryExit:
                    IsIgnoreVisible = IsRetryVisible = IsExitVisible = true;
                    break;
                default:
                    break;
            }

        }

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

        [RelayCommand]
        void DragMoveBtn(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) App.Current.Services.GetDialogService()?.OperationDialog(this, EOperationDialog.DragMove);
        }
        [RelayCommand]
        void OkBtn()=> CloseDialog(EDialogResult.OK);

        [RelayCommand]
        void CancelBtn() => CloseDialog(EDialogResult.Cancel);
        [RelayCommand]
        void RetryBtn() => CloseDialog(EDialogResult.Retry);

        [RelayCommand]
        void IgnoreBtn()=> CloseDialog(EDialogResult.Ignore);

        [RelayCommand]
        void ExitBtn()=> CloseDialog(EDialogResult.Exit);

        void CloseDialog(EDialogResult result = EDialogResult.OK)
        {
            DialogResult = result;
            App.Current.Services.GetDialogService()?.CloseDialog(this);
        }
    }
}
