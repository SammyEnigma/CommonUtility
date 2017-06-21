using CommonUtility.Logging;
using System;
using System.Diagnostics;
using System.Reflection;

namespace CommonUtility.PerformanceMonitor
{
    public class PerformanceMonitorScope : IDisposable
    {
        static private readonly Logger mLogger = new Logger(MethodBase.GetCurrentMethod().DeclaringType);


        static private Level performanceMonitorLogLevel = Level.Info;
        /// <summary>
        /// Log最低输出级别
        /// </summary>
        static public Level PerformanceMonitorLogLevel
        {
            get { return performanceMonitorLogLevel; }
            set { performanceMonitorLogLevel = value; }
        }

        private Level mLogLevel;
        private string mInfo;

        private Stopwatch mStopwatch;

        public PerformanceMonitorScope(string info) : this(Level.Info, info)
        {
        }

        public PerformanceMonitorScope(Level level, string info)
        {
            this.mLogLevel = level;
            this.mInfo = info;

            if (level > PerformanceMonitorLogLevel)
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
