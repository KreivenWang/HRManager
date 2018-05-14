using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using HRManagerClient.Utility;

namespace HRManagerClient
{
    class ExpireRemindConverter : IValueConverter
    {

        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string expireStr = (string)value;
            if (expireStr == null) return null;
            var expireDate = DateTime.Parse(expireStr);
            int day = DateTime.Now.GetDateSpanDays(expireDate);
            if (day > 0)
                return "距离合同到期还有" + day + "天";
            return "已到期";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
