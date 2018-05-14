using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;

namespace HRManagerClient
{
    class EmployeeManagerViewModel : DBOperateViewModel<Employee>
    {
        const string All = "全部";
        readonly DateTime DefaultDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        public IEnumerable FiltedItems
        {
            get
            {
                IEnumerable<Employee> filtered = Model;
                if (!String.IsNullOrEmpty(NameFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.EmployeeBaseInfo.EmployName) 
                        && item.EmployeeBaseInfo.EmployName.Contains(NameFilterText));
                }
                if (!String.IsNullOrEmpty(WorkNumFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.EmployeeNO) && item.EmployeeNO.Contains(WorkNumFilterText));
                }
                if (!String.IsNullOrEmpty(PhoneFilterText)) {
                    filtered = filtered.Where(item =>!String.IsNullOrWhiteSpace(item.EmployeeBaseInfo.Phone) && item.EmployeeBaseInfo.Phone.Contains(PhoneFilterText));
                }
                if (!String.IsNullOrEmpty(CurSiteFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.EmployeeBaseInfo.CurSite) && item.EmployeeBaseInfo.CurSite.Contains(CurSiteFilterText));
                }
                if (SexFilter != SexEnum.Unknown) {
                    filtered = filtered.Where(item => item.EmployeeBaseInfo.Sex == SexFilter);
                }
                if (JobStateFilter != JobStatusEnum.Other) {
                    filtered = filtered.Where(item => item.State == JobStateFilter);
                }
                if (HireDateStartFilter != DefaultDate || HireDateEndFilter != DefaultDate) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.HireDate) && DateTime.Compare(DateTime.Parse(item.HireDate), HireDateStartFilter) >= 0 && DateTime.Compare(DateTime.Parse(item.HireDate), HireDateEndFilter) <= 0);
                }
                return filtered;
            }
        }

        #region NameFilterText 属性
        private string _backfield_NameFilterText;
        public string NameFilterText
        {
            get { return _backfield_NameFilterText; }
            set
            {
                _backfield_NameFilterText = value;
                RaisePropertyChanged("NameFilterText");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region WorkNumFilterText 属性
        private string _backfield_WorkNumFilterText;
        public string WorkNumFilterText
        {
            get { return _backfield_WorkNumFilterText; }
            set
            {
                _backfield_WorkNumFilterText = value;
                RaisePropertyChanged("WorkNumFilterText");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region PhoneFilterText 属性
        private string _backfield_PhoneFilterText;
        public string PhoneFilterText
        {
            get { return _backfield_PhoneFilterText; }
            set
            {
                _backfield_PhoneFilterText = value;
                RaisePropertyChanged("PhoneFilterText");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region CurSiteFilterText 属性
        private string _backfield_CurSiteFilterText;
        public string CurSiteFilterText
        {
            get { return _backfield_CurSiteFilterText; }
            set
            {
                _backfield_CurSiteFilterText = value;
                RaisePropertyChanged("CurSiteFilterText");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region SexFilter 属性
        private SexEnum _backfield_SexFilter;
        public SexEnum SexFilter
        {
            get { return _backfield_SexFilter; }
            set
            {
                _backfield_SexFilter = value;
                RaisePropertyChanged("SexFilter");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region JobStateFilter 属性
        private JobStatusEnum _backfield_JobStateFilter;
        public JobStatusEnum JobStateFilter
        {
            get { return _backfield_JobStateFilter; }
            set
            {
                _backfield_JobStateFilter = value;
                RaisePropertyChanged("JobStateFilter");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region HireDateStartFilter 属性
        private DateTime _backfield_HireDateStartFilter;
        public DateTime HireDateStartFilter
        {
            get { return _backfield_HireDateStartFilter; }
            set
            {
                _backfield_HireDateStartFilter = value;
                RaisePropertyChanged("HireDateStartFilter");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region HireDateEndFilter 属性
        private DateTime _backfield_HireDateEndFilter;
        public DateTime HireDateEndFilter
        {
            get { return _backfield_HireDateEndFilter; }
            set
            {
                _backfield_HireDateEndFilter = value;
                RaisePropertyChanged("HireDateEndFilter");
                RaisePropertyChanged("FiltedItems");
            }
        }
        #endregion

        public ICommand ShowEmployeeDetailCommand { get; set; }
        public ICommand ClearFilterCommand { get; set; }

        public EmployeeManagerViewModel(EntityCollection<Employee> model)
            : base(model)
        {
            ShowEmployeeDetailCommand = new RelayCommand(ShowEmployeeDetail);
            ClearFilterCommand = new RelayCommand(InitializeFilter);
            InitializeFilter();

            RegistReceiverSlot(EmployeeEditViewModel.DetailChangedToken, DetailChanged);
        }

        private void DetailChanged()
        {
            SaveChanges();
        }

        private void InitializeFilter()
        {
            NameFilterText = null;
            WorkNumFilterText = null;
            PhoneFilterText = null;
            CurSiteFilterText = null;
            SexFilter = SexEnum.Unknown;
            JobStateFilter = JobStatusEnum.Other;
            HireDateStartFilter = DefaultDate;
            HireDateEndFilter = DefaultDate;
        }

        private void ShowEmployeeDetail()
        {
            if (SelectedItem == null) return;
            EmployeeEditViewModel.ShowDetailDialog(SelectedItem, false);
        }

        protected override Employee GetNewItemInstance()
        {
            var newNo = GetDefaultNewNo();
            Employee m = new Employee()
            {
                EmployeeNO = newNo.ToString(),
                EmployeeBaseInfo = new EmployeeBaseInfo(),
                EmployeePostAdjusts = new List<EmployeePostAdjust>()
            };
            return EmployeeEditViewModel.ShowDetailDialog(m, true) ? m : null;
        }

        private int GetDefaultNewNo()
        {
            var list = Model.ToList();
            if (list.Count > 0)
                return list.Max(e => int.Parse(e.EmployeeNO)) + 1;
            return 100001;
        }
    }
}
