using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using HRModel;
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using HrControl;


namespace HRManagerClient
{
    /// <summary>
    /// CreateAskLeaveDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CreateAskLeaveDialog : CreateDocumentBillDialog
    {
        public IEnumerable LeaveTypeItems
        {
            get { return null; } //SystemArgumentControl.GetArguments(ArguType.OverWorkType); }
            }

        public CreateAskLeaveDialog(IDocumentBill newModelExample)
            : base(newModelExample)
        {
            InitializeComponent();
        }

        protected override bool CanSubmit()
        {
            var m = ModelExample as AskLeave;
            return base.CanSubmit() && m.BeginDate != null && m.EndDate != null; //&& m.LeaveType != null;
        }

        protected override void Submit()
        {
            var m = ModelExample as AskLeave;
            if (DateTime.Parse(m.BeginDate) >= DateTime.Parse(m.EndDate))
                MessageBox.Show("起始日期不能大于结束日期");
            else
                base.Submit();
        }
    }
}
