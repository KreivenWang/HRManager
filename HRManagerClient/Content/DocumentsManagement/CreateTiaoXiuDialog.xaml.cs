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
    /// CreateTiaoXiuDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CreateTiaoXiuDialog : CreateDocumentBillDialog
    {
        public CreateTiaoXiuDialog(IDocumentBill newModelExample)
            : base(newModelExample)
        {
            InitializeComponent();
        }
    }
}
