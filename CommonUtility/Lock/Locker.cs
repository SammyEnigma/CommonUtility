using System.Collections.Generic;

namespace CommonUtility.Lock
{
    public class Locker
    {
        private static readonly object SyncObj = new object();
        private static readonly Dictionary<string, object> Lockers = new Dictionary<string, object>();

        public static object GetLocker(string name)
        {
            if (!Lockers.TryGetValue(name, out var locker))
                lock (SyncObj)
                {
                    if (!Lockers.TryGetValue(name, out locker))
                    {
                        locker = new object();
                        Lockers[name] = locker;
                    }
                }

            return locker;
        }
    }
}