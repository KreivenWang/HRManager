using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace HRManagerClient.Utility
{
    class VaccationYearToDateConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int year = int.Parse(value.ToString());
            int month = int.Parse(parameter.ToString());
            return new DateTime(year, month, 1);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //datetime => string
            return null;
        }

        #endregion
    }
}
