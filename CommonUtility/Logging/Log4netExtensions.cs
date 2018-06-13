using L4nLevel = log4net.Core.Level;

namespace CommonUtility.Logging
{
    public static class Log4netExtensions
    {
        public static L4nLevel Log4netLevel(this LogLevel level)
        {
            L4nLevel nLevel;
            switch (level)
            {
                case LogLevel.Trace:
                    nLevel = L4nLevel.Trace;
                    break;
                case LogLevel.Debug:
                    nLevel = L4nLevel.Debug;
                    break;
                case LogLevel.Warning:
                    nLevel = L4nLevel.Warn;
                    break;
                case LogLevel.Information:
                    nLevel = L4nLevel.Info;
                    break;
                case LogLevel.Error:
                    nLevel = L4nLevel.Error;
                    break;
                case LogLevel.Critical:
                    nLevel = L4nLevel.Fatal;
                    break;
                default:
                case LogLevel.None:
                    nLevel = L4nLevel.Off;
                    break;
            }

            return nLevel;
        }
    }
}