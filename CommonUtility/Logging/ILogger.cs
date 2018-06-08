using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtility.Logging
{
    /// <summary>
    /// Represents a type used to perform logging.
    /// </summary>
    /// <remarks>Aggregates most logging patterns to a single method.</remarks>
    public interface ILogger
    {
        void Log<T>(LogLevel level, T message);
        void Log(LogLevel level, Exception exception, IFormatProvider provider, string message, params object[] args);
    }
}
