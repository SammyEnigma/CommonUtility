using log4net;
using log4net.Util;
using System;

namespace CommonUtility.Logging
{
    public class Log4netLogger : ILogger
    {
        private readonly static Type ThisDeclaringType = typeof(Log4netLogger);

        private ILog _logger;

        public Log4netLogger(ILog log)
        {
            _logger = log;
        }

        public void Log<T>(LogLevel level, T message)
        {
            _logger.Logger.Log(ThisDeclaringType, level.Log4netLevel(), message, null);
        }

        public void Log(LogLevel level, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            _logger.Logger.Log(ThisDeclaringType, level.Log4netLevel(), new SystemStringFormat(provider, message, args), exception);
        }
    }
}
