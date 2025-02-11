using CommunityToolkit.Mvvm.ComponentModel;
using Platform.Extensions.Enum;
using Platform.Extensions.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Extensions
{
    public class ViewModeBase
    {
    }
    /// <summary>
    /// 用于弹窗
    /// </summary>
    public  abstract class ViewModelBaseDialog:ObservableRecipient,IviewModel
    {
        protected readonly ILogger? _logger;
        protected ViewModelBaseDialog(ILogger logger)
        {
            this._logger = logger;
        }
        protected ViewModelBaseDialog()
        {
            
        }
        private Stopwatch _stopWatch = new();
        EShowDialogBtnState buttonState;
        public EShowDialogBtnState ButtonState { get => buttonState; set => SetProperty(ref buttonState, value); }

        EloggerLevel level;
        public EloggerLevel Level { get => level; set => SetProperty(ref level, value); }

        EDialogResult dialogResult = EDialogResult.None;
        public EDialogResult DialogResult { get =>dialogResult; set=>SetProperty(ref dialogResult,value); }
        EloggerMoudel moudel = EloggerMoudel.View;
        public EloggerMoudel Moudel { get => moudel; set => SetProperty(ref moudel, value); }
        string message = string.Empty;
        public string Message { get => message; set => SetProperty(ref message, value); }
        string title = string.Empty;
        public string Title { get => title; set => SetProperty(ref title, value); }
        public void AddBeginLog()
        {
            _stopWatch.Restart();
            //_logger.LogAny(Level, "Begin ===" + message.Replace("\r\n", ":"), Title ?? string.Empty, Moudel);
        }
        public void AddEndLog()
        {
            if (_stopWatch.IsRunning) _stopWatch.Stop();
            //_logger.LogAny(Level, "End ===" + message.Replace("\r\n", ":"), Title ?? string.Empty, Moudel);
        }
    }
    /// <summary>
    /// 用于线程弹窗
    /// </summary>
    public abstract class ViewModelBaseDialogAsync : ObservableRecipient, IviewModel
    {
        protected readonly ILogger? _logger;
        protected ViewModelBaseDialogAsync(ILogger logger)
        {
            this._logger = logger;
        }
        protected ViewModelBaseDialogAsync()
        {

        }
        private Stopwatch _stopWatch = new();
        EShowDialogBtnState buttonState;
        public EShowDialogBtnState ButtonState { get => buttonState; set => SetProperty(ref buttonState, value); }

        EloggerLevel level;
        public EloggerLevel Level { get => level; set => SetProperty(ref level, value); }

        EDialogResult dialogResult = EDialogResult.None;
        public EDialogResult DialogResult { get => dialogResult; set => SetProperty(ref dialogResult, value); }
        EloggerMoudel moudel = EloggerMoudel.View;
        public EloggerMoudel Moudel { get => moudel; set => SetProperty(ref moudel, value); }
        string message = string.Empty;
        public string Message { get => message; set => SetProperty(ref message, value); }
        string title = string.Empty;
        public string Title { get => title; set => SetProperty(ref title, value); }
        public void AddBeginLog()
        {
            _stopWatch.Restart();
            _logger.LogAny(Level, "Begin ===" + message.Replace("\r\n", ":"), Title ?? string.Empty, Moudel);
        }
        public void AddEndLog()
        {
            if (_stopWatch.IsRunning) _stopWatch.Stop();
            _logger.LogAny(Level, "End ===" + message.Replace("\r\n", ":"), Title ?? string.Empty, Moudel);
        }

        public void AddErrorLog(string message)=> _logger.LogAny(EloggerLevel.Error, message, Title ?? string.Empty, Moudel);
        public void AddErrorLog(Exception ex) => _logger.LogAny(EloggerLevel.Error, ex, Title ?? string.Empty, Moudel);

    }

}
