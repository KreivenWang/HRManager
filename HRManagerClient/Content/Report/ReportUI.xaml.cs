
using System;
using System.Windows.Controls;
using HRModel;
using Steelsa.Localization;

namespace HRManagerClient
{
    /// <summary>
    /// ReportUI.xaml 的交互逻辑
    /// </summary>
    public partial class ReportUI : Control
    {
        private readonly Type _reportItemType;

        public ReportUI(Type reportItemType)
        {
            _reportItemType = reportItemType;
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType != typeof (string)
                || e.PropertyName == nameof(AttendanceResult.AskLeaveTypesStr)) {
                e.Cancel = true;
                return;
            }
            e.Column.Header = _reportItemType.PropLocalize(e.PropertyName);
            e.Column.IsReadOnly = true;
            switch (e.PropertyName) {
                case nameof(EmployeeReport.EmployeeNo):
                    e.Column.DisplayIndex = 0;
                    break;
                case nameof(EmployeeReport.EmployeeName):
                    e.Column.DisplayIndex = 1;
                    break;
                case nameof(EmployeeReport.DepartName):
                    e.Column.DisplayIndex = 2;
                    break;
                case nameof(EmployeeReport.OperatingPostName):
                    e.Column.DisplayIndex = 3;
                    break;
            }
        }
    }
}
