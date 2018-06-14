using System;
using log4net;
using log4net.Util;

namespace CommonUtility.Logging
{
    public class Log4netLogger : ILogger
    {
        private static readonly Type ThisDeclaringType = typeof(Log4netLogger);

        private readonly ILog _logger;

        public Log4netLogger(ILog log)
        {
            _logger = log;
        }

        public void Log<T>(LogLevel level, T message)
        {
            _logger.Logger.Log(ThisDeclaringType, level.Log4netLevel(), message, null);
        }

        public void Log(LogLevel level, Exception exception, IFormatProvider provider, string message,
            params object[] args)
        {
            _logger.Logger.Log(ThisDeclaringType, level.Log4netLevel(), new SystemStringFormat(provider, message, args),
                exception);
        }
    }
}