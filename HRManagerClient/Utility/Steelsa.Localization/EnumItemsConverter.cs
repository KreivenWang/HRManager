using System;
using System.Collections;
using System.Linq;

namespace Steelsa.Localization
{
    public static class EnumItemsConverter
    {
        public static IEnumerable GetEnumLocalizedItems<T>(this object viewModel)
        {
            return Enum.GetValues(typeof(T)).OfType<T>().ToList().ConvertAll(t => new EnumItem<T>(t));
        }
    }

    public class EnumItem<T>
    {
        public T SelectedValue { get; private set; }

        public string DisplayMember
        {
            get
            {
                return SelectedValue.EnumLocalize();
            }
        }

        public EnumItem(T value)
        {
            SelectedValue = value;
        }
    }
}
