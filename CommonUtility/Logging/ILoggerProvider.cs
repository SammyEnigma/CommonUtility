using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtility.Logging
{
    /// <summary>
    /// Represents a type that can create instances of <see cref="ILogger"/>.
    /// </summary>
    public interface ILoggerProvider : IDisposable
    {
        /// <summary>
        /// Creates a new <see cref="ILogger"/> instance.
        /// </summary>
        /// <param name="categoryName">The category name for messages produced by the logger.</param>
        /// <returns></returns>
        ILogger CreateLogger(string categoryName);
    }
}
