using System;
using System.Globalization;

namespace CommonUtility.Logging
{
    /// <summary>
    ///     Recommend Use LogFactory
    /// </summary>
    public class Logger
    {
        private static readonly LogFactory LogFactory;

        private readonly ILogger _logger;

        static Logger()
        {
            LogFactory = new LogFactory();
            LogFactory.AddProvider(NLogProvider.Instance);
        }

        public Logger(string name)
        {
            _logger = LogFactory.CreateLogger(name);
        }

        public Logger(Type type) : this(type.FullName)
        {
        }

        public void Debug(string format, params object[] args)
        {
            Debug(CultureInfo.InvariantCulture, format, args);
        }

        public void Debug(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Debug(null, provider, format, args);
        }

        public void Error(string format, params object[] args)
        {
            Error(CultureInfo.InvariantCulture, format, args);
        }

        public void Error(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Error(null, provider, format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            Fatal(CultureInfo.InvariantCulture, format, args);
        }

        public void Fatal(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Fatal(null, provider, format, args);
        }

        public void Info(string format, params object[] args)
        {
            Info(CultureInfo.InvariantCulture, format, args);
        }

        public void Info(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Info(null, provider, format, args);
        }

        public void Warn(string format, params object[] args)
        {
            Warn(CultureInfo.InvariantCulture, format, args);
        }

        public void Warn(IFormatProvider provider, string format, params object[] args)
        {
            _logger.Warn(null, provider, format, args);
        }

#pragma warning disable CS0618 // 类型或成员已过时
        public void Log<T>(Level level, T message, Exception exception = null)
#pragma warning restore CS0618 // 类型或成员已过时
        {
            Log(level.ToLogLevel(), message, exception);
        }

        public void Log<T>(LogLevel level, T message, Exception exception = null)
        {
            if (exception == null)
                _logger.Log(level, message);
            else
                _logger.Log(level, exception, CultureInfo.InvariantCulture, message.ToString());
        }
    }
}