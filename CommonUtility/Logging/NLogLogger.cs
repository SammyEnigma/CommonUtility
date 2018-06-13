using System;

namespace CommonUtility.Logging
{
    public class NLogLogger : ILogger
    {
        private readonly NLog.Logger _logger;

        public NLogLogger(NLog.Logger logger)
        {
            _logger = logger;
        }

        public void Log<T>(LogLevel level, T message)
        {
            _logger.Log(level.NLogLevel(), message);
        }

        public void Log(LogLevel level, Exception exception, IFormatProvider provider, string message,
            params object[] args)
        {
            _logger.Log(level.NLogLevel(), exception, provider, message, args);
        }
    }
}