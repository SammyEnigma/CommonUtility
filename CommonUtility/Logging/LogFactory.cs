using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CommonUtility.Logging
{
    public class LogFactory : ILoggerFactory
    {
        private static readonly object SyncObj = new object();
        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        private readonly List<ILoggerProvider> _providers = new List<ILoggerProvider>();

        public void AddProvider(ILoggerProvider provider)
        {
            _providers.Add(provider);
        }

        public ILogger CreateLogger(string categoryName)
        {
            lock (SyncObj)
            {
                return _loggers.GetOrAdd(categoryName, delegate
                {
                    return new InternalLogger
                    {
                        Loggers = CreateLoggers(categoryName)
                    };
                });
            }
        }

        public void Dispose()
        {
            _loggers.Clear();
            _providers.ForEach(p =>
            {
                try
                {
                    p.Dispose();
                }
                catch
                {
                }
            });
            _providers.Clear();
        }

        private ILogger[] CreateLoggers(string categoryName)
        {
            var loggers = new ILogger[_providers.Count];
            for (var i = 0; i < _providers.Count; i++) loggers[i] = _providers[i].CreateLogger(categoryName);

            return loggers;
        }
    }
}