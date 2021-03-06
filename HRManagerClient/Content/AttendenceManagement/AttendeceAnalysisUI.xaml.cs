﻿using System;
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
    /// AttendeceAnalysisUI.xaml 的交互逻辑
    /// </summary>
    public partial class AttendeceAnalysisUI : Control
    {
        public AttendeceAnalysisUI()
        {
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
//            var realModelType = (DataContext as AttendeceAnalysisViewModel)?.RealModelType;
//            if (realModelType == null) return;
//            if (realModelType.IsNonAutoColumn(e.PropertyName)) {
//                e.Cancel = true;
//                return;
//            }
            var coName = (DataContext as AttendeceAnalysisViewModel)?.RealModelType.PropLocalize(e.PropertyName);
            if (string.IsNullOrEmpty(coName)) {
                e.Cancel = true;
                return;
            }
            e.Column.Header = coName;
            //e.Column.IsReadOnly = true;
        }

        private void DataGrid_OnAutoGeneratedColumns(object sender, EventArgs e)
        {
            var d = sender as DataGrid;
            if (d == null) return;
            foreach (var leaveTypeName in AskLeaveTypeControl.GetLeaveTypeNames()) {
                //converter:
                //list <count ,type> => count . where(type.name == header)
                var c = new DataGridTextColumn {
                    Binding = new Binding {
                        Path = new PropertyPath("AskLeaveTypeForAttendances"),
                        Converter = new DynamicAskLeaveTypeToCountConverter(),
                        ConverterParameter = leaveTypeName
                    },
                    Header = leaveTypeName,
                    Width = new DataGridLength(0, DataGridLengthUnitType.Auto)
                };
                d.Columns.Add(c);
            }
        }

        private void DataGrid_OnSorting(object sender, DataGridSortingEventArgs e)
        {
            if (e.Column.Header.ToString() == typeof (AttendanceResult).PropLocalize(nameof(AttendanceResult.AttendanceDateDay)))
                e.Column.SortMemberPath = nameof(AttendanceResult.AttendanceDateToDatetime) + ".Day";
        }
    }

    public class DynamicAskLeaveTypeToCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var alist = (List<AskLeaveTypeForAttendance>)value;
            var typename = (string)parameter;
            if (alist == null || typename == null)
                return -1;
            var found = alist.Find(a => a.AskLeaveType.LeaveName == typename);
            if (found == null)
                return -1;
            return found.TimeCount;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
