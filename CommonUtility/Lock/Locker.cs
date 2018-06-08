using System.Collections.Generic;

namespace CommonUtility.Lock
{
    public class Locker
    {
        static readonly object mLockObj = new object();
        static Dictionary<string, object> mLockers = new Dictionary<string, object>();

        public static object GetLocker(string name)
        {
            if (!mLockers.TryGetValue(name, out object locker))
            {
                lock (mLockObj)
                {
                    if (!mLockers.TryGetValue(name, out locker))
                    {
                        locker = new object();
                        mLockers[name] = locker;
                    }
                }
            }
            return locker;
        }
    }
}
