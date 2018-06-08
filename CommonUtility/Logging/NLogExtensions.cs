
using NLogLogLevel = NLog.LogLevel;

namespace CommonUtility.Logging
{
    public static class NLogExtensions
    {
        public static NLogLogLevel NLogLevel(this LogLevel level)
        {
            NLogLogLevel nLogLevel;
            switch (level)
            {
                case LogLevel.Trace:
                    nLogLevel = NLogLogLevel.Trace;
                    break;
                case LogLevel.Debug:
                    nLogLevel = NLogLogLevel.Debug;
                    break;
                case LogLevel.Information:
                    nLogLevel = NLogLogLevel.Info;
                    break;
                case LogLevel.Warning:
                    nLogLevel = NLogLogLevel.Warn;
                    break;
                case LogLevel.Error:
                    nLogLevel = NLogLogLevel.Error;
                    break;
                case LogLevel.Critical:
                    nLogLevel = NLogLogLevel.Fatal;
                    break;
                case LogLevel.None:
                default:
                    nLogLevel = NLogLogLevel.Off;
                    break;
            }

            return nLogLevel;
        }
    }
}
