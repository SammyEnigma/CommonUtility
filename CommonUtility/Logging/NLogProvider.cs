using System;
using System.Collections.Concurrent;
using NLog;

namespace CommonUtility.Logging
{
    public class NLogProvider : ILoggerProvider
    {
        public static string ConfigFile = "nlog.config";

        private static readonly Lazy<NLogProvider> Provider =
            new Lazy<NLogProvider>(() => new NLogProvider(), true);

        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private NLogProvider()
        {
            LogManager.LoadConfiguration(ConfigFile);
        }

        public static ILoggerProvider Instance => Provider.Value;

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new NLogLogger(LogManager.GetLogger(categoryName)));
        }

        public void Dispose()
        {
            _loggers.Clear();
            LogManager.Shutdown();
        }
    }
}