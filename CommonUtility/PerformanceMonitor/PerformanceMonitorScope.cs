using System;
using System.Diagnostics;
using System.Reflection;
using CommonUtility.Logging;

namespace CommonUtility.PerformanceMonitor
{
    public class PerformanceMonitorScope : IDisposable
    {
        private static readonly Logger Logger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);


        private readonly string _info;

        private readonly LogLevel _logLevel;

        private Stopwatch _stopwatch;

        public PerformanceMonitorScope(string info) : this(LogLevel.Information, info)
        {
        }

#pragma warning disable CS0618 // 类型或成员已过时
        public PerformanceMonitorScope(Level level, string info) : this(level.ToLogLevel(), info)
#pragma warning restore CS0618 // 类型或成员已过时
        {
        }

        public PerformanceMonitorScope(LogLevel level, string info)
        {
            _logLevel = level;
            _info = info;

            if (level > LowestPerformanceMonitorLogLevel) _stopwatch = Stopwatch.StartNew();
        }

        /// <summary>
        ///     Lowest output level of log
        /// </summary>
#pragma warning disable CS0618 // 类型或成员已过时
        public static Level PerformanceMonitorLogLevel
#pragma warning restore CS0618 // 类型或成员已过时
        {
            get { return LowestPerformanceMonitorLogLevel.ToLevel(); }
            set { LowestPerformanceMonitorLogLevel = value.ToLogLevel(); }
        }

        public static LogLevel LowestPerformanceMonitorLogLevel { get; set; } = LogLevel.Information;

        public void Dispose()
        {
            if (_stopwatch != null)
            {
                _stopwatch.Stop();
                Logger.Log(_logLevel,
                    string.Format("Operation: {0}, Execution time: {1} ms", _info, _stopwatch.ElapsedMilliseconds));
                _stopwatch = null;
            }
        }
    }
}