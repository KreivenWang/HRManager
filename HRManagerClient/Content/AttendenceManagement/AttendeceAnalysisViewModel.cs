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
using GalaSoft.MvvmLight.Threading;
using HrControl;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HRManagerClient
{
    class AttendeceAnalysisViewModel: DBOperateViewModel<AttendanceResult>
    {
        public const string ToVacationPlanPageToken = "AttendeceAnalysisViewModel.ToVacationPlanPageToken";
        private DateTime _defaultTime;

        public ObservableCollection<AttendanceResult> FiltedItems { get; set; }
        public ICommand AnalyseCommand { get; set; }
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

        #region StartDate 属性
        private DateTime _backfield_StartDate;
        public DateTime StartDate
        {
            get { return _backfield_StartDate; }
            set
            {
                _backfield_StartDate = value;
                RaisePropertyChanged(() => StartDate);
            }
        }
        #endregion

        #region EndDate 属性
        private DateTime _backfield_EndDate;

        public DateTime EndDate
        {
            get { return _backfield_EndDate; }
            set
            {
                _backfield_EndDate = value;
                RaisePropertyChanged(() => EndDate);
            }
        }
        #endregion

        #region AnalyseMonth 属性
        private int _backfield_AnalyseMonth;
        public int AnalyseMonth
        {
            get { return _backfield_AnalyseMonth; }
            set
            {
                _backfield_AnalyseMonth = value;
                RaisePropertyChanged(() => AnalyseMonth);
            }
        }
        #endregion

        #region AnalyseYear 属性
        private int _backfield_AnalyseYear;
        public int AnalyseYear
        {
            get { return _backfield_AnalyseYear; }
            set
            {
                _backfield_AnalyseYear = value;
                RaisePropertyChanged(() => AnalyseYear);
            }
        }
        #endregion

        public AttendeceAnalysisViewModel(EntityCollection<AttendanceResult> model)
            : base(model)
        {
            FiltedItems = new ObservableCollection<AttendanceResult>();
            AnalyseCommand = new RelayCommand(Analyse);
            SelectEpCommand = new RelayCommand(SelectEp);
            SearchCommand = new RelayCommand(Search);
            _defaultTime = DateTime.Now;
            StartDate = _defaultTime;
            EndDate = _defaultTime;
            AnalyseYear = DateTime.Now.Year;
            AnalyseMonth = DateTime.Now.Month;
        }

        private void Analyse()
        {
            if (AnalyseYear == 0)
            {
                MessageBox.Show("请输入分析年份");
                return;
            }
            if (AnalyseMonth == 0)
            {
                MessageBox.Show("请输入分析月份");
                return;
            }
            ModelSource.UpdateData();
            if (ModelSource.DefVacationPlans.Count == 0)
            {
                if (MessageBox.Show("请确保至少有一个公用的休假方案! 是否转到\"休假方案管理\"?", "缺少信息", MessageBoxButton.YesNo) ==
                    MessageBoxResult.Yes)
                    SendSignal(ToVacationPlanPageToken);
                return;
            }
            DoProgress(delegate
            {
                (Model.EntityCtrl as AttendanceResultControl).Analysis(new DateTime(AnalyseYear, AnalyseMonth, 1));
                MessageBox.Show(string.Format("{0}年{1}月份考勤分析完成! 请按筛选条件查询分析结果.", AnalyseYear, AnalyseMonth));
            },$"正在分析{AnalyseYear}年{AnalyseMonth}月的员工考勤记录...");
        }

        private void Search()
        {
            DoProgress(delegate
            {
                ModelSource.UpdateData();
                Model = ModelSource.AttendanceResults;
                var items = Model.ToList().Where(a =>
                    (string.IsNullOrEmpty(FilterEpName) || a.EmployeeName.Contains(FilterEpName)) &&
                    (string.IsNullOrEmpty(FilterEpNo) || a.EmployeeNo.Contains(FilterEpNo))).ToList();
                if (!items.Any()) {
                    MessageBox.Show("查无结果");
                } else {
                    DispatcherHelper.UIDispatcher.BeginInvoke(new Action(() =>
                    {
                        FiltedItems.Clear();
                        foreach (var item in items) {
                            FiltedItems.Add(item);
                        }
                    }));
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
