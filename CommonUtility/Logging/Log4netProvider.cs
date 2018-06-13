using System;
using System.Collections.Concurrent;
using System.IO;
using log4net;
using log4net.Config;

namespace CommonUtility.Logging
{
    public class Log4netProvider : ILoggerProvider
    {
        public static string ConfigFile = "log4net.config";

        private static readonly Lazy<Log4netProvider> Provider =
            new Lazy<Log4netProvider>(() => new Log4netProvider(), true);

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private Log4netProvider()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigFile));
        }

        public static ILoggerProvider Instance => Provider.Value;

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new Log4netLogger(LogManager.GetLogger(categoryName)));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}