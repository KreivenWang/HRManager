using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using HrControl;
using HRModel;
using Steelsa.Localization;

namespace HRManagerClient
{
    /// <summary>
    /// SalaryDetailUI.xaml 的交互逻辑
    /// </summary>
    public partial class SalaryDetailUI : Control
    {
        public SalaryDetailUI()
        {
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var coName = (DataContext as SalaryDetailViewModel)?.RealModelType.PropLocalize(e.PropertyName);
            if (string.IsNullOrEmpty(coName)) {
                e.Cancel = true;
                return;
            }
            e.Column.Header = coName;
            //e.Column.IsReadOnly = true;
        }
    }
}
