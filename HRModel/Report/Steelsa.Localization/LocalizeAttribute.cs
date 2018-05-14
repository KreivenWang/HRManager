using System;

namespace Steelsa.Localization
{
    /// <summary>
    /// 为类中的属性或枚举中的字段设置本地化显示值
    /// </summary>
    [Serializable]
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class LocalizeAttribute : Attribute
    {
        public string Name { get; protected set; }

        public LocalizeAttribute()
        {

        }

        public LocalizeAttribute(string name)
        {
            Name = name;
        }
    }

    /// <summary>
    /// 为类中的属性或枚举中的字段设置本地化显示值, 需要LocalizationManager初始化资源
    /// </summary>
    [Serializable]
    [System.AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class LocalizeFromResAttribute : LocalizeAttribute
    {

        public LocalizeFromResAttribute(string key)
        {
            if (LocalizationManager.ResManagerSource != null) {
                var value = LocalizationManager.ResManagerSource.GetObject(key);
                if (value != null) {
                    Name = value.ToString();
                }
            }
        }
    }

    [Serializable]
    [System.AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class NonAutoColumnAttribute : Attribute
    {
        public NonAutoColumnAttribute()
        {
            
        }
    }
}
