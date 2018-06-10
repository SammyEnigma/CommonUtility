using CommonUtility.Logging;
using System;
using System.Diagnostics;
using System.Reflection;

namespace CommonUtility.PerformanceMonitor
{
    public class PerformanceMonitorScope : IDisposable
    {
        static private readonly Logger mLogger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);


        static private LogLevel performanceMonitorLogLevel = LogLevel.Information;
        /// <summary>
        /// Lowest output level of log
        /// </summary>
#pragma warning disable CS0618 // 类型或成员已过时
        static public Level PerformanceMonitorLogLevel
#pragma warning restore CS0618 // 类型或成员已过时
        {
            get { return performanceMonitorLogLevel.ToLevel(); }
            set { performanceMonitorLogLevel = value.ToLogLevel(); }
        }
        static public LogLevel LowestPerformanceMonitorLogLevel
        {
            get { return performanceMonitorLogLevel; }
            set { performanceMonitorLogLevel = value; }
        }

        private LogLevel mLogLevel;
        private string mInfo;

        private Stopwatch mStopwatch;

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
            this.mLogLevel = level;
            this.mInfo = info;

            if (level > LowestPerformanceMonitorLogLevel)
            {
                this.mStopwatch = Stopwatch.StartNew();
            }
        }

        public void Dispose()
        {
            if (this.mStopwatch != null)
            {
                this.mStopwatch.Stop();
                mLogger.Log(mLogLevel, string.Format("Operation: {0}, Execution time: {1} ms", mInfo, this.mStopwatch.ElapsedMilliseconds));
                this.mStopwatch = null;
            }
        }
    }
}
