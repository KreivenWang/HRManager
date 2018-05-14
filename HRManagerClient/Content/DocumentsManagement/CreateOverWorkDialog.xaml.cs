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
    /// CreateOverWorkDialog.xaml 的交互逻辑
    /// </summary>
    public partial class CreateOverWorkDialog : CreateDocumentBillDialog
    {
        #region IsOffdutyFall 属性
        private bool _backfield_IsOffdutyFall;
        public bool IsOffdutyFall
        {
            get { return _backfield_IsOffdutyFall; }
            set
            {
                _backfield_IsOffdutyFall = value;
                OnPropertyChanged("IsOffdutyFall");
            }
        }
        #endregion

        #region IsOnDutyFall 属性
        private bool _backfield_IsOnDutyFall;
        public bool IsOnDutyFall
        {
            get { return _backfield_IsOnDutyFall; }
            set
            {
                _backfield_IsOnDutyFall = value;
                OnPropertyChanged("IsOnDutyFall");
            }
        }
        #endregion

        #region ApplyTime 属性
        private string _backfield_ApplyTime;
        public string ApplyTime
        {
            get { return _backfield_ApplyTime; }
            set
            {
                _backfield_ApplyTime = value;
                OnPropertyChanged("ApplyTime");
                (ModelExample as OverWork).ApplyTime = value;
            }
        }
        #endregion

        #region StartTime 属性
        private DateTime _backfield_StartTime;
        public DateTime StartTime
        {
            get { return _backfield_StartTime; }
            set
            {
                _backfield_StartTime = value;
                OnPropertyChanged("StartTime");
                (ModelExample as OverWork).BeginDateTime = value.ToString();
                ApplyTime = (EndTime - StartTime).TotalHours.ToString();
            }
        }
        #endregion

        #region EndTime 属性
        private DateTime _backfield_EndTime;
        public DateTime EndTime
        {
            get { return _backfield_EndTime; }
            set
            {
                _backfield_EndTime = value;
                OnPropertyChanged("EndTime");
                (ModelExample as OverWork).EndDateTime = value.ToString();
                ApplyTime = (EndTime - StartTime).TotalHours.ToString();
            }
        }
        #endregion

        public IEnumerable OverWorkTypeItems
        {
            get { return SystemArgumentControl.GetArguments(ArguType.OverWorkType); }
        }

        public CreateOverWorkDialog(IDocumentBill newModelExample)
            : base(newModelExample)
        {
            InitializeComponent();
            StartTime = DateTime.Today;
            EndTime = DateTime.Today;
        }

        protected override bool CanSubmit()
        {
            var m = ModelExample as OverWork;
            return base.CanSubmit() && m.ApplyTime != null && m.BeginDateTime != null && m.EndDateTime != null;
        }

        protected override void Submit()
        {
            var m = ModelExample as OverWork;
            if (StartTime >= EndTime)
                MessageBox.Show("起始日期不能大于结束日期");
            else
                base.Submit();
        }
    }
}
