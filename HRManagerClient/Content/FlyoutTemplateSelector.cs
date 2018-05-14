using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HRManagerClient
{
    public class FlyoutTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DpSelectTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is DpSelectVM) {
                return DpSelectTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
