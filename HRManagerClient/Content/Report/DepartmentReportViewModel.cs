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
    class DepartmentReportViewModel : ReportViewModel<DepartmentSalaryReport>
    {
        public IEnumerable FiltedItems
        {
            get
            {
                IEnumerable<DepartmentSalaryReport> filtered = Model;
                if (!string.IsNullOrEmpty(FilterDepartmentName)) {
                    filtered =
                        filtered.Where(r => !string.IsNullOrEmpty(r.Department.DepartName) &&
                        r.Department.DepartName.Contains(FilterDepartmentName));
                }
                return filtered;
            }
        }


        #region FilterDepartmentName 属性
        private string _backfieldFilterDepartmentName;
        public string FilterDepartmentName
        {
            get { return _backfieldFilterDepartmentName; }
            set
            {
                _backfieldFilterDepartmentName = value;
                RaisePropertyChanged(() => FilterDepartmentName);
                RaisePropertyChanged(() => FiltedItems);
            }
        }
        #endregion

        #region SelectDp 命令
        private ICommand _cmdSelectDp;
        public ICommand SelectDpCommand => _cmdSelectDp ?? (_cmdSelectDp = new RelayCommand(SelectDp));

        private void SelectDp()
        {
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog()) {
                FilterDepartmentName = dlg.SelectedDpvm.Model.DepartName;
            }
        }

        #endregion

        public DepartmentReportViewModel(ObservableCollection<DepartmentSalaryReport> model) : base(model)
        {
        }
    }
}