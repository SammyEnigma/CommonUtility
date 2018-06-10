using log4net.Config;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace CommonUtility.Logging
{
    public class Log4netProvider : ILoggerProvider
    {
        public static string ConfigFile = "log4net.config";

        private static Lazy<Log4netProvider> provider = new Lazy<Log4netProvider>(delegate { return new Log4netProvider(); }, true);
        public static ILoggerProvider Instance => provider.Value;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private Log4netProvider()
        {
            XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigFile));
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new Log4netLogger(log4net.LogManager.GetLogger(categoryName)));
        }

        public void Dispose()
        {
            _loggers.Clear();
        }
    }
}
