using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CommonUtility.Logging
{
    public class LogFactory : ILoggerFactory
    {
        private static object _sync = new object();

        private List<ILoggerProvider> providers = new List<ILoggerProvider>();
        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        public void AddProvider(ILoggerProvider provider)
        {
            providers.Add(provider);
        }

        public ILogger CreateLogger(string categoryName)
        {
            lock (_sync)
            {
                return _loggers.GetOrAdd(categoryName, delegate
                {
                    return new InternalLogger
                    {
                        Loggers = CreateLoggers(categoryName),
                    };
                });
            }
        }

        public void Dispose()
        {
            _loggers.Clear();
            providers.ForEach(p =>
            {
                try { p.Dispose(); } catch { }
            });
            providers.Clear();
        }

        private ILogger[] CreateLoggers(string categoryName)
        {
            var loggers = new ILogger[providers.Count];
            for (int i = 0; i < providers.Count; i++)
            {
                loggers[i] = providers[i].CreateLogger(categoryName);
            }

            return loggers;
        }
    }
}
