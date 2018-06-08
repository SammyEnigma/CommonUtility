using System;
using System.Collections.Concurrent;

namespace CommonUtility.Logging
{
    public class NLogProvider : ILoggerProvider
    {
        public static string ConfigFile = "nlog.config";

        private static Lazy<NLogProvider> provider = new Lazy<NLogProvider>(delegate { return new NLogProvider(); }, true);
        public static ILoggerProvider Instance => provider.Value;

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private NLogProvider()
        {
            NLog.LogManager.LoadConfiguration(ConfigFile);
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new NLogLogger(NLog.LogManager.GetLogger(categoryName)));
        }

        public void Dispose()
        {
            _loggers.Clear();
            NLog.LogManager.Shutdown();
        }
    }
}
