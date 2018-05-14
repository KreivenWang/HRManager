using System;
using System.Linq;

namespace Steelsa.Localization
{
    public static class LocalizeAttributeFinderExtension
    {
        /// <summary>
        /// 从特性中寻找本地化枚举值(若无法找到, 则从资源中寻找key="Enum类名_字段名"(如:TestEnum_First)的资源)
        /// </summary>
        public static string EnumLocalize<T>(this T obj)
        {
            var objType = obj.GetType();
            var fieldInfo = objType.GetField(obj.ToString());//枚举值为字段
            var result = GetLocalizedName(fieldInfo);//从特性中寻找本地化值

            if (string.IsNullOrEmpty(result)) { //从资源中寻找key="Enum类名_字段名"
                var resKey = objType.Name + "_" + fieldInfo.Name;
                if (LocalizationManager.ResManagerSource != null) {
                    result = (string)LocalizationManager.ResManagerSource.GetObject(resKey);
                }
            }
            return result as string;
        }

        /// <summary>
        /// 从特性中寻找本地化属性值
        /// </summary>
        public static string PropLocalize(this Type belongType, string propName)
        {
            var propInfo = belongType.GetProperty(propName);
            return GetLocalizedName(propInfo);
        }

        public static bool IsNonAutoColumn(this Type belongType, string propName)
        {
            var propInfo = belongType.GetProperty(propName);
            var attrs = propInfo?.GetCustomAttributes(typeof(NonAutoColumnAttribute), true);
            return attrs?.Length == 1;
        }


        private static string GetLocalizedName(System.Reflection.MemberInfo memberInfo)
        {
            LocalizeAttribute foundAttr = null;
            if (memberInfo != null) {
                object[] attrs = memberInfo.GetCustomAttributes(typeof(LocalizeAttribute), true);
                if (attrs.Count() == 1)
                    foundAttr = attrs[0] as LocalizeAttribute;
            }

            if (foundAttr == null)
                return null;
            return foundAttr.Name;
        }
    }
}
