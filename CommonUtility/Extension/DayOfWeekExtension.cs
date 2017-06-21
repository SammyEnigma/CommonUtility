using System;

namespace CommonUtility.Extension
{
    static public class DayOfWeekExtension
    {
        static public bool IsWeekend(this DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
