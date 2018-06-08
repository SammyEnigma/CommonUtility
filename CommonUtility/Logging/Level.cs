using System;

namespace CommonUtility.Logging
{
    [Obsolete("use LogLevel instead", false)]
    public enum Level
    {
        Trace = LogLevel.Trace,
        Debug = LogLevel.Debug,
        Warn = LogLevel.Warning,
        Info = LogLevel.Information,
        Error = LogLevel.Error,
        Fatal = LogLevel.Critical,
        None = LogLevel.None,
    }
}
