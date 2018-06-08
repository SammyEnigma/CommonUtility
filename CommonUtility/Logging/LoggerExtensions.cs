using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtility.Logging
{
    public static class LoggerExtensions
    {
        public static void Trace<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.Trace, message);
        }

        public static void Trace(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.Trace, exception, provider, message, args);
        }

        public static void Debug<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.Debug, message);
        }

        public static void Debug(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.Debug, exception, provider, message, args);
        }

        public static void Info<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.Information, message);
        }

        public static void Info(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.Information, exception, provider, message, args);
        }

        public static void Warn<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.Warning, message);
        }

        public static void Warn(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.Warning, exception, provider, message, args);
        }

        public static void Error<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.Error, message);
        }

        public static void Error(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.Error, exception, provider, message, args);
        }

        public static void Fatal<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.Critical, message);
        }

        public static void Fatal(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.Critical, exception, provider, message, args);
        }

        public static void None<T>(this ILogger logger, T message)
        {
            logger.Log(LogLevel.None, message);
        }

        public static void None(this ILogger logger, Exception exception, IFormatProvider provider, string message, params object[] args)
        {
            logger.Log(LogLevel.None, exception, provider, message, args);
        }
    }
}
