using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Extensions.Enum
{
    public enum EDialogResult
    {
        None = -1,
        OK,
        Cancel,
        Retry,
        Ignore,
        Exit,
    }
    public enum EOperationDialog
    {
        Close,
        DragMove,
        Hide,
        Show,
        WindowState_Minimized,
        WindowState_Maximized,
        WindowState_Normal,
    }

    public enum EShowDialogBtnState
    {
        OK,
        OkCancel,
        IgnoreRetryExit
    }

    public enum EloggerLevel
    {
        All = -1,
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
        UI,
    }

    public enum EloggerMoudel
    {
        Default,
        WorkProcess,
        ManualControl,
        Model,
        View,
        ViewModel,
        PropertyChange,
        MotionPlatform,
    }


}
