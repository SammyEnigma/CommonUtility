using System;

namespace CommonUtility.Logging
{
    public class InternalLogger : ILogger
    {
        public ILogger[] Loggers { get; set; }

        public void Log<T>(LogLevel level, T message)
        {
            if (null == Loggers) return;

            var loggers = Loggers;
            foreach (var logger in loggers)
            {
                try { logger.Log(level, message); } catch { }
            }
        }

        public void Log(LogLevel level, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            if (null == Loggers) return;

            var loggers = Loggers;
            foreach (var logger in loggers)
            {
                try { logger.Log(level, exception, provider, message, args); } catch { }
            }
        }
    }
}
