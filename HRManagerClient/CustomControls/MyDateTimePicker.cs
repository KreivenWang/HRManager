using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TimePicker = System.Windows.Forms.DateTimePicker;

namespace HRManagerClient.CustomControls
{
    class MyDateTimePicker : Control
    {
        TimePicker PART_TimePicker;

        public DateTime Time
        {
            get { return (DateTime)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(DateTime), typeof(MyDateTimePicker), new PropertyMetadata(new PropertyChangedCallback(TimeChangedCallback)));

        private static void TimeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null || (DateTime)e.NewValue == default(DateTime)) return;
            var pk = d as MyDateTimePicker;
            pk.PART_TimePicker.Value = (DateTime)e.NewValue;
        }

        public MyDateTimePicker()
        {
            BindStyle(this, @"CustomControls/MyDateTimePicker.xaml");
            PART_TimePicker = (TimePicker)this.Template.FindName("PART_TimePicker", this);
            PART_TimePicker.ValueChanged += PART_TimePicker_ValueChanged;
        }

        void PART_TimePicker_ValueChanged(object sender, EventArgs e)
        {
            Time = PART_TimePicker.Value;
        }

        public string CustomFormat
        {
            get { return (string)GetValue(CustomFormatProperty); }
            set { SetValue(CustomFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomFormat.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomFormatProperty =
            DependencyProperty.Register("CustomFormat", typeof(string), typeof(MyDateTimePicker), new PropertyMetadata(new PropertyChangedCallback(CustomFormatChangedCallback)));

        private static void CustomFormatChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var format = (string)e.NewValue;
            if (string.IsNullOrEmpty(format)) return;
            var pk = d as MyDateTimePicker;
            pk.PART_TimePicker.CustomFormat = format;
        }

        public static void BindStyle(FrameworkElement element, string resourcePath)
        {
            string assemblyName = element.GetType().Assembly.FullName;
            try {
                ResourceDictionary resDict = new ResourceDictionary();
                resDict.Source = new Uri(String.Format(@"pack://application:,,,/{0};component/{1}", assemblyName, resourcePath), UriKind.RelativeOrAbsolute);
                element.Resources.MergedDictionaries.Add(resDict);
                element.ApplyTemplate();
            } catch (Exception ex) {
                Console.WriteLine("{0} BindStyle Failed! Uri: {1} of {2} Not found. \n{3}", element, resourcePath, assemblyName, ex.Message);
            }
        }
    }
}
