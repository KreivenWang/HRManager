
using System;
using System.Windows.Controls;
using HRModel;
using Steelsa.Localization;

namespace HRManagerClient
{
    /// <summary>
    /// DepartmentReportUI.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentReportUI : Control
    {
        private readonly Type _reportItemType;

        public DepartmentReportUI(Type reportItemType)
        {
            _reportItemType = reportItemType;
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType != typeof(string)) {
                e.Cancel = true;
                return;
            }
            e.Column.Header = _reportItemType.PropLocalize(e.PropertyName);
            e.Column.IsReadOnly = true;
        }
    }
}
