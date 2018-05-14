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
    /// CreateReSignInDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CreateReSignInDialog : CreateDocumentBillDialog
    {
        public IEnumerable ReSignInTypeItems
        {
            get { return SystemArgumentControl.GetArguments(ArguType.ReSignInType); }
        }

        public IEnumerable ReSignInReasonTypeItems
        {
            get { return SystemArgumentControl.GetArguments(ArguType.ReSignInReasonType); }
        }

        public CreateReSignInDialog(IDocumentBill newModelExample)
            : base(newModelExample)
        {
            InitializeComponent();
        }

        protected override bool CanSubmit()
        {
            var m = ModelExample as ReSignIn;
            return base.CanSubmit() && m.ReSignInDate != null && m.ReSignInType != null && m.Reason != null;
        }

        protected override void Submit()
        {
            var m = ModelExample as ReSignIn;
            if (DateTime.Parse(m.ReSignInDate) >= DateTime.Now)
                MessageBox.Show("补签日期不能大于今天");
            else
                base.Submit();
        }
    }
}
