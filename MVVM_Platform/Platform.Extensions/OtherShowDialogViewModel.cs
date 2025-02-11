using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Platform.Extensions.Enum;
using Platform.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Platform.Extensions
{
    public partial class OtherShowDialogViewModel:ViewModelBaseDialog
    {
        public OtherShowDialogViewModel(ILogger logger, EloggerLevel level, string message, string title
            , EShowDialogBtnState dialogBtnState = EShowDialogBtnState.OK) : base(logger)
        {
            Level = level;
            Message = message;
            Title = title;
            ButtonState = dialogBtnState;
            switch (ButtonState)
            {
                case EShowDialogBtnState.OK:
                    IsOkVisible = true;
                    break;
                case EShowDialogBtnState.OkCancel:
                    IsOkVisible = true;
                    IsCancelVisible = true;
                    break;
                case EShowDialogBtnState.IgnoreRetryExit:
                    IsRetryVisible = IsExitVisible = IsIgnoreVisible = true;
                    break;
                default:
                    break;
            }
        }

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


        [RelayCommand]
        void DragMoveBtn(object ? parameter)
        {
            if (parameter is Window window) window.DragMove();
        }
        [RelayCommand]
        void OkBtn(object? parameter)
        {
            DialogResult = EDialogResult.OK;
            if (parameter is Window window) window.Close();

        }

        [RelayCommand]
        void CancelBtn(object? parameter)
        {
            DialogResult = EDialogResult.Cancel;
            if (parameter is Window window) window.Close();
        }
        [RelayCommand]
        void RetryBtn(object? parameter)
        {
            DialogResult = EDialogResult.Retry;
            if (parameter is Window window) window.Close();
        }
        [RelayCommand]
        void IgnoreBtn(object? parameter)
        {
            DialogResult = EDialogResult.Ignore;
            if (parameter is Window window) window.Close();
        }
        [RelayCommand]
        void ExitBtn(object? parameter)
        {
            DialogResult = EDialogResult.Exit;
            if (parameter is Window window) window.Close();
        }
    }
}
