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
    /// CreateBusinessTripDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CreateBusinessTripDialog : CreateDocumentBillDialog
    {
        public CreateBusinessTripDialog(IDocumentBill newModelExample)
            : base(newModelExample)
        {
            InitializeComponent();
        }

        protected override bool CanSubmit()
        {
            var m = ModelExample as BusinessTrip;
            return base.CanSubmit() && m.BeginDate != null && m.EndDate != null;
        }

        protected override void Submit()
        {
            var m = ModelExample as BusinessTrip;
            if (DateTime.Parse(m.BeginDate) >= DateTime.Parse(m.EndDate))
                MessageBox.Show("起始日期不能大于结束日期");
            else
            base.Submit();
        }
    }
}
