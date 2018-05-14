using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace HRManagerClient.Utility
{
    class StringToDateTimeConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //string => datetime
            DateTime result;
            DateTime.TryParse((string) value, out result);
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //datetime => string
            return value?.ToString();
        }

        #endregion
    }
}
