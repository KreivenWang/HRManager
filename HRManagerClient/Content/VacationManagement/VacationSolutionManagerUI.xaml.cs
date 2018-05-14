using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRManagerClient.Utility;

namespace HRManagerClient
{
    /// <summary>
    /// VacationSolutionManagerUI.xaml 的交互逻辑
    /// </summary>
    public partial class VacationSolutionManagerUI : Control
    {
        private VacationSolutionManagerViewModel Vm
        {
            get { return DataContext as VacationSolutionManagerViewModel; }
        }

        public VacationSolutionManagerUI()
        {
            InitializeComponent();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var calendarGrid = Template.FindName("calendarGrid", this) as Grid;
            if (calendarGrid != null) Vm.Calendars = calendarGrid.FindChildren<Calendar>().ToList();
        }

        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Vm.SelectedVSln == null) return;
            if (!Vm.IsInitializingSelectedVSln)
            {
                Vm.SelectedVSln.Model.VacationDays.RemoveAll(dt => e.RemovedItems.OfType<DateTime>().Contains(dt));
                Vm.SelectedVSln.Model.VacationDays.AddRange(e.AddedItems.OfType<DateTime>());
                System.Diagnostics.Trace.WriteLine("当前选中节假日天数: " + Vm.SelectedVSln.Model.VacationDays.Count);
            }
            
        }

        private void CalendarItem_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.Captured is CalendarItem) {
                var c = Mouse.Captured as CalendarItem;
                var calendar= VisualHelper.VisualUpwardSearch<Calendar>(e.OriginalSource as DependencyObject) as Calendar;
                if (calendar != null) {
                    //calendar.sele
                }
                Mouse.Capture(null);
            }
        }
    }
}
