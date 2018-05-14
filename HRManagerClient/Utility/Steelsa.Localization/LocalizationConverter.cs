using System;

namespace Steelsa.Localization
{
    /// <summary>
    /// <para>若本地化枚举值, 则直接绑定到属性, value为属性值, 无需parameter</para>
    /// <para>如: {Binding TEnum, Converter={StaticResource LocalizationConverter}}</para>
    /// <para>---------------------------------------------------------------------</para>
    /// <para>若本地化属性值, 则绑定到属性所属对象, value为属性所属对象, parameter为属性名称</para>
    /// <para>如: {Binding ConverterParameter=propName, Converter={StaticResource LocalizationConverter}}</para>
    /// </summary>
    public class LocalizationConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null) {
                if (parameter == null) { //parameter as propName
                    var localName = value.EnumLocalize();
                    return localName;
                } else {
                    var localName = value.GetType().PropLocalize(parameter.ToString());
                    return localName;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
