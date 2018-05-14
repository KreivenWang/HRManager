using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using HrControl;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HRManagerClient
{
    class SalaryDetailViewModel : DBOperateViewModel<WageDetail>
    {
        public ObservableCollection<WageDetail> FiltedItems { get; set; }
        public ICommand SelectEpCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        #region FilterEpName 属性
        private string _backfield_FilterEpName;
        public string FilterEpName
        {
            get { return _backfield_FilterEpName; }
            set
            {
                _backfield_FilterEpName = value;
                RaisePropertyChanged(() => FilterEpName);
            }
        }
        #endregion

        #region FilterEpNo 属性
        private string _backfield_FilterEpNo;
        public string FilterEpNo
        {
            get { return _backfield_FilterEpNo; }
            set
            {
                _backfield_FilterEpNo = value;
                RaisePropertyChanged(() => FilterEpNo);
            }
        }
        #endregion

        public SalaryDetailViewModel(EntityCollection<WageDetail> model)
            : base(model)
        {
            FiltedItems = new ObservableCollection<WageDetail>();
            SelectEpCommand = new RelayCommand(SelectEp);
            SearchCommand = new RelayCommand(Search);
        }

        private void Search()
        {
            DoProgress(delegate
            {
                ModelSource.UpdateData();
                Model = ModelSource.SalaryDetails;
                var items = Model.ToList().Where(a =>
                    (string.IsNullOrEmpty(FilterEpName) || a.Employee.EmployeeBaseInfo.EmployName.Contains(FilterEpName)) &&
                    (string.IsNullOrEmpty(FilterEpNo) || a.Employee.EmployeeNO.Contains(FilterEpNo))).ToList();
                if (!items.Any()) {
                    MessageBox.Show("查无结果");
                } else {
                    FiltedItems.Clear();
                    foreach (var item in items) {
                        FiltedItems.Add(item);
                    }
                }
            },"正在查询...");
        }

        private void SelectEp()
        {
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog())
            {
                FilterEpName = dlg.SelectedEp.EmployeeBaseInfo.EmployName;
                FilterEpNo = dlg.SelectedEp.EmployeeNO;
            }
        }
    }
}
