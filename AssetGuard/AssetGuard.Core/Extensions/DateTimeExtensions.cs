using System;

namespace AssetGuard.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsWeekday(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }
    }
}
