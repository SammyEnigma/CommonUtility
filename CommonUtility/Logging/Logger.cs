using System;
using System.Globalization;

namespace CommonUtility.Logging
{
    /// <summary>
    /// Recommend Use LogFactory
    /// </summary>
    public class Logger
    {
        static LogFactory logFactory;
        static Logger()
        {
            logFactory = new LogFactory();
            logFactory.AddProvider(NLogProvider.Instance);
        }

        private ILogger mlogger = null;

        public Logger(string name)
        {
            mlogger = logFactory.CreateLogger(name);
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
            mlogger.Debug(null, provider, format, args);
        }

        public void Error(string format, params object[] args)
        {
            Error(CultureInfo.InvariantCulture, format, args);
        }

        public void Error(IFormatProvider provider, string format, params object[] args)
        {
            mlogger.Error(null, provider, format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            Fatal(CultureInfo.InvariantCulture, format, args);
        }

        public void Fatal(IFormatProvider provider, string format, params object[] args)
        {
            mlogger.Fatal(null, provider, format, args);
        }

        public void Info(string format, params object[] args)
        {
            Info(CultureInfo.InvariantCulture, format, args);
        }

        public void Info(IFormatProvider provider, string format, params object[] args)
        {
            mlogger.Info(null, provider, format, args);
        }

        public void Warn(string format, params object[] args)
        {
            Warn(CultureInfo.InvariantCulture, format, args);
        }

        public void Warn(IFormatProvider provider, string format, params object[] args)
        {
            mlogger.Warn(null, provider, format, args);
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
            {
                mlogger.Log(level, message);
            }
            else
            {
                mlogger.Log(level, exception, CultureInfo.InvariantCulture, message.ToString());
            }
        }
    }
}
