using Platform.Extensions.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Extensions.Interfaces
{
    public interface ILogger
    {
        void LogAny(EloggerLevel level, string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogAny(EloggerLevel level, Exception ex, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);

        void LogAll(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);

        void LogTrace(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogDebug(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogInfo(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogWarn(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogError(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogFatal(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);
        void LogUI(string message, string title = "", EloggerMoudel moudel = EloggerMoudel.Default);


        void Dispose();
        string GetFuncName();
        string GetUpFuncName();

        string GetLoggerBasePath();

    }
}
