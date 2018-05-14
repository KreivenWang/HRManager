using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using HRModel;

namespace HRManagerClient
{
    class EmployeeReportViewModel<T> : ReportViewModel<T>
        where T : IEmployeeReport
    {
        public IEnumerable FiltedItems
        {
            get
            {
                IEnumerable<T> filtered = Model;
                if (!string.IsNullOrEmpty(FilterEpName)) {
                    filtered = filtered.Where(item => !string.IsNullOrWhiteSpace(item.EmployeeName)
                                                      && item.EmployeeName.Contains(FilterEpName));
                }
                if (!string.IsNullOrEmpty(FilterEpNo)) {
                    filtered = filtered.Where(item => !string.IsNullOrWhiteSpace(item.EmployeeNo) && item.EmployeeNo.Contains(FilterEpNo));
                }
                return filtered;
            }
        }


        #region FilterEpName ÊôÐÔ
        private string _backfield_FilterEpName;
        public string FilterEpName
        {
            get { return _backfield_FilterEpName; }
            set
            {
                _backfield_FilterEpName = value;
                RaisePropertyChanged(() => FilterEpName);
                RaisePropertyChanged(() => FiltedItems);
            }
        }
        #endregion

        #region FilterEpNo ÊôÐÔ
        private string _backfield_FilterEpNo;
        public string FilterEpNo
        {
            get { return _backfield_FilterEpNo; }
            set
            {
                _backfield_FilterEpNo = value;
                RaisePropertyChanged(() => FilterEpNo);
                RaisePropertyChanged(() => FiltedItems);
            }
        }
        #endregion

        #region SelectEp ÃüÁî
        private ICommand _cmdSelectEp;
        public ICommand SelectEpCommand => _cmdSelectEp ?? (_cmdSelectEp = new RelayCommand(SelectEp));

        private void SelectEp()
        {
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog()) {
                FilterEpName = dlg.SelectedEp.EmployeeBaseInfo.EmployName;
                FilterEpNo = dlg.SelectedEp.EmployeeNO;
            }
        }
        #endregion

        public EmployeeReportViewModel(ObservableCollection<T> model)
            : base(model)
        {

        }
    }
}