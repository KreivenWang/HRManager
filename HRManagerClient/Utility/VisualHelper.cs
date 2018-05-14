using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace HRManagerClient.Utility
{
    public class VisualHelper
    {
        public static DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
                source = System.Windows.Media.VisualTreeHelper.GetParent(source);

            return source;
        }
    }
}
