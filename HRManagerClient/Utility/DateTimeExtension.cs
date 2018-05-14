using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManagerClient.Utility
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取当前日期至截止日期的间隔天数, 当前日期>截止日期则返回0天
        /// </summary>
        public static int GetDateSpanDays(this DateTime dateBegin, DateTime dateEnd)
        {
            TimeSpan ts1 = new TimeSpan(dateBegin.Ticks);
            TimeSpan ts2 = new TimeSpan(dateEnd.Ticks);
            var result = ts2.Subtract(ts1);
            if (result != result.Duration()) {
                return 0;
            } else {
                return result.Days;
            }
        }

        public static int GetDateSpanDays(this DateTime dateBegin, string dateEndStr)
        {
            if (string.IsNullOrEmpty(dateEndStr)) return 0;
            return dateBegin.GetDateSpanDays(DateTime.Parse(dateEndStr));
        }
    }
}
