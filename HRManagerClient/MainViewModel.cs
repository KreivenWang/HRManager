using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagerClient.Utility;
using System.Windows.Input;
using System.Windows;
using HRModel;
using HRManagerDataAccess;
using System.Collections.ObjectModel;
using HrControl;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using Steelsa;


namespace HRManagerClient
{
    class MainViewModel : ViewModelBase<ModelSource>, IStatusConsole
    {
        public static MainWindow MainWindowHandler { get; set; }

        MainPageUI _mainPageUI;

        #region StatusText 属性
        private string _backfield_StatusText;
        public string StatusText
        {
            get { return _backfield_StatusText; }
            set
            {
                _backfield_StatusText = value;
                RaisePropertyChanged(() => StatusText);
            }
        }
        #endregion

        #region CurUserName 属性
        private string _backfield_CurUserName;
        public string CurUserName
        {
            get { return _backfield_CurUserName; }
            set
            {
                _backfield_CurUserName = value;
                RaisePropertyChanged(() => CurUserName);
            }
        }
        #endregion

        #region CurUserType 属性
        private string _backfield_CurUserType;
        public string CurUserType
        {
            get { return _backfield_CurUserType; }
            set
            {
                _backfield_CurUserType = value;
                RaisePropertyChanged(() => CurUserType);
            }
        }
        #endregion

        #region Content 属性
        private Control _backfield_Content;
        public Control Content
        {
            get { return _backfield_Content; }
            set
            {
                _backfield_Content = value;
                RaisePropertyChanged("Content");
            }
        }
        #endregion

        #region IsMainPageTabItemSelected 属性
        private bool _backfield_IsMainPageTabItemSelected;
        public bool IsMainPageTabItemSelected
        {
            get { return _backfield_IsMainPageTabItemSelected; }
            set
            {
                _backfield_IsMainPageTabItemSelected = value;
                RaisePropertyChanged(() => IsMainPageTabItemSelected);
                if (_backfield_IsMainPageTabItemSelected)
                {
                    if (_mainPageUI == null)
                    {
                        _mainPageUI = new MainPageUI();
                        _mainPageUI.DataContext = this;
                    }
                    Content = _mainPageUI;
                }
            }
        }
        #endregion

        #region IsHRTabItemSelected 属性
        private bool _backfield_IsHRTabItemSelected;
        public bool IsHRTabItemSelected
        {
            get { return _backfield_IsHRTabItemSelected; }
            set
            {
                _backfield_IsHRTabItemSelected = value;
                RaisePropertyChanged(() => IsHRTabItemSelected);
            }
        }
        #endregion

        #region IsAttTabItemSelected 属性
        private bool _backfield_IsAttTabItemSelected;
        public bool IsAttTabItemSelected
        {
            get { return _backfield_IsAttTabItemSelected; }
            set
            {
                _backfield_IsAttTabItemSelected = value;
                RaisePropertyChanged(() => IsAttTabItemSelected);
            }
        }
        #endregion

        #region IsSysTabItemSelected 属性
        private bool _backfield_IsSysTabItemSelected;
        public bool IsSysTabItemSelected
        {
            get { return _backfield_IsSysTabItemSelected; }
            set
            {
                _backfield_IsSysTabItemSelected = value;
                RaisePropertyChanged(() => IsSysTabItemSelected);
            }
        }
        #endregion

        #region IsRptTabItemSelected 属性
        private bool _backfield_IsRptTabItemSelected;
        public bool IsRptTabItemSelected
        {
            get { return _backfield_IsRptTabItemSelected; }
            set
            {
                _backfield_IsRptTabItemSelected = value;
                RaisePropertyChanged(() => IsRptTabItemSelected);
            }
        }
        #endregion

        #region StatusMessage 属性
        private string _backfield_StatusMessage;
        public string StatusMessage
        {
            get { return _backfield_StatusMessage; }
            set
            {
                _backfield_StatusMessage = value;
                RaisePropertyChanged(() => StatusMessage);
            }
        }
        #endregion
        public ICommand EmployeeManageCommand { get; set; }
        public ICommand DepartmentManageCommand { get; set; }
        public ICommand OperatingPostManageCommand { get; set; }
        public ICommand OnJobManageCommand { get; set; }
        public ICommand OffJobManageCommand { get; set; }
        public ICommand DormitoryManageCommand { get; set; }
        public ICommand PostTransferManageCommand { get; set; }
        public ICommand SalarySetCommand { get; set; }

        public ICommand VaccationSolutionCommand { get; set; }
        public ICommand VaccationSolutionAsignCommand { get; set; }
        public ICommand AskLeaveManageCommand { get; set; }
        public ICommand BusinessTripManageCommand { get; set; }
        public ICommand ReSignInManageCommand { get; set; }
        public ICommand OverWorkManageCommand { get; set; }
        public ICommand DefWorkArrangeCommand { get; set; }
        public ICommand AsignWorkArrangeCommand { get; set; }
        public ICommand CardFillRecordManageCommand { get; set; }
        public ICommand AttendanceManageCommand { get; set; }
        public ICommand TiaoXiuManageCommand { get; set; }
        public ICommand AttendanceAnalysisCommand { get; set; }
        public ICommand SalaryDetailCommand { get; set; }


        public ICommand SysArgsManageCommand { get; set; }
        public ICommand SysUserManageCommand { get; set; }
        public ICommand SysRoleManageCommand { get; set; }
        public ICommand AttArgManageCommand { get; set; }
        public ICommand BaseSalaryManageCommand { get; set; }
        public ICommand TaxManageCommand { get; set; }

        public ICommand ReportEmployeeProfileCommand { get; set; }
        public ICommand ReportEmployeeTransferCommand { get; set; }
        public ICommand ReportEmployeeDayAttCommand { get; set; }
        public ICommand ReportEmployeeMonthAttCommand { get; set; }
        public ICommand ReportDepartmentSalaryCommand { get; set; }
        public ICommand ReportEmployeeSalaryCommand { get; set; }


        public ICommand MainWindowLoadedCommand { get; set; }
        public MainViewModel()
        {
            StatusConsole.Initialize(this);
            EmployeeManageCommand = new RelayCommand(ShowEmployeeManageUI);
            DepartmentManageCommand = new RelayCommand(ShowDepartmentManageUI);
            OperatingPostManageCommand = new RelayCommand(ShowOperatingPostManagerUI);
            OnJobManageCommand = new RelayCommand(ShowOnJobManageUI);
            OffJobManageCommand = new RelayCommand(ShowOffJobManageUI);
            DormitoryManageCommand = new RelayCommand(ShowDormitoryManageUI);
            PostTransferManageCommand = new RelayCommand(ShowPostTransferManageUI);
            SalarySetCommand = new RelayCommand(SalarySet);

            VaccationSolutionCommand = new RelayCommand(ShowVaccationSolutionUI);
            VaccationSolutionAsignCommand = new RelayCommand(ShowVaccationSolutionAsignUI);
            AskLeaveManageCommand = new RelayCommand(ShowAskLeaveManageUI);
            BusinessTripManageCommand = new RelayCommand(ShowBusinessTripManageUI);
            ReSignInManageCommand = new RelayCommand(ShowReSignInManageUI);
            OverWorkManageCommand = new RelayCommand(ShowOverWorkManageUI);
            DefWorkArrangeCommand = new RelayCommand(ShowWkarDefineUI);
            AsignWorkArrangeCommand = new RelayCommand(ShowWkarAsignUI);
            CardFillRecordManageCommand = new RelayCommand(CardFillRecordManage);
            AttendanceManageCommand = new RelayCommand(AttendanceManage);
            TiaoXiuManageCommand = new RelayCommand(TiaoXiuManage);
            AttendanceAnalysisCommand = new RelayCommand(ShowAttendanceAnalysis);
            SalaryDetailCommand = new RelayCommand(ShowSalaryDetail);

            SysArgsManageCommand = new RelayCommand(ShowSysArgsManageUI);
            SysUserManageCommand = new RelayCommand(SysUserManage);
            SysRoleManageCommand = new RelayCommand(SysRoleManage);
            AttArgManageCommand = new RelayCommand(AttArgManage);
            BaseSalaryManageCommand = new RelayCommand(BaseSalaryManage);
            TaxManageCommand = new RelayCommand(TaxManage);

            MainWindowLoadedCommand = new RelayCommand(OnMainWindowLoaded);

            ReportEmployeeProfileCommand = new RelayCommand(ReportEmployeeProfile);
            ReportEmployeeTransferCommand = new RelayCommand(ReportEmployeeTransfer);
            ReportEmployeeDayAttCommand = new RelayCommand(ReportEmployeeDayAtt);
            ReportEmployeeMonthAttCommand = new RelayCommand(ReportEmployeeMonthAttendence);
            ReportDepartmentSalaryCommand = new RelayCommand(ReportDepartmentSalary);
            ReportEmployeeSalaryCommand = new RelayCommand(ReportEmployeeSalary);

            IsMainPageTabItemSelected = true;

            RegistReceiverSlot(AttendeceAnalysisViewModel.ToVacationPlanPageToken, ShowVaccationSolutionUI);
        }

        private void OnMainWindowLoaded()
        {
            ShowExpireTip();
            CurUserName = ModelSource.CurrentUser.UserName;
            CurUserType = ModelSource.CurrentUser.SystemRole.Name;
            StatusConsole.WriteLine(CurUserName + "已登录, 欢迎使用!");
        }

        #region 报表

        private void ReportEmployeeDayAtt()
        {
            TurnToRptPage(new ReportUI(typeof(EmployeeDayAttendenceReport)), new EmployeeReportViewModel<EmployeeDayAttendenceReport>(ModelSource.EmployeeDayAttendenceReports));
        }

        private void ReportEmployeeTransfer()
        {
            TurnToRptPage(new ReportUI(typeof(EmployeeTransferReport)), new EmployeeReportViewModel<EmployeeTransferReport>(ModelSource.EmployeeTransferReports));
        }

        private void ReportEmployeeSalary()
        {
            TurnToRptPage(new ReportUI(typeof (EmployeeSalaryReport)), new EmployeeReportViewModel<EmployeeSalaryReport>(ModelSource.EmployeeSalaryReports));
        }

        private void ReportDepartmentSalary()
        {
            TurnToRptPage(new DepartmentReportUI(typeof(DepartmentSalaryReport)), new DepartmentReportViewModel(ModelSource.DepartmentSalaryReports));
        }

        private void ReportEmployeeMonthAttendence()
        {
            TurnToRptPage(new ReportUI(typeof(EmployeeMonthAttendenceReport)), new EmployeeReportViewModel<EmployeeMonthAttendenceReport>(ModelSource.EmployeeMonthAttendenceReports));
        }

        private void ReportEmployeeProfile()
        {
            TurnToRptPage(new ReportUI(typeof(EmployeeProfileReport)), new EmployeeReportViewModel<EmployeeProfileReport>(ModelSource.EmployeeProfileReports));
        }

        private void TurnToRptPage(Control v, ViewModelBase vm)
        {
            v.DataContext = vm;
            IsRptTabItemSelected = true;
            Content = v;
            StatusConsole.WriteReady();
        }

        #endregion

        #region 系统设置

        private void SysUserManage()
        {
            TurnToSysPage(new SystemUserManagerUI(), new SystemUserManagerViewModel(ModelSource.SystemUsers));
        }

        private void SysRoleManage()
        {
            TurnToSysPage(new SystemRoleManagerUI(), new SystemRoleManagerViewModel(ModelSource.SystemRoles));
        }

        private void AttArgManage()
        {
            TurnToSysPage(new AttArgsManagerUI(), new AttArgsManagerViewModel(ModelSource.AttArgControl));
        }

        private void ShowSysArgsManageUI()
        {
            TurnToSysPage(new SystemArgsManagerUI(), new SystemArgsManagerViewModel(ModelSource.SystemArguments));
        }

        private void BaseSalaryManage()
        {
            TurnToSysPage(new BaseSalaryManagerUI(), new BaseSalaryManagerViewModel(ModelSource.BaseSalaryControl));
        }

        private void TaxManage()
        {
            TurnToSysPage(new TaxManagerManagerUI(), new TaxManagerViewModel(ModelSource.TaxControl));
        }

        private void TurnToSysPage(Control v, ViewModelBase vm)
        {
            v.DataContext = vm;
            IsSysTabItemSelected = true;
            Content = v;
            StatusConsole.WriteReady();
        }

        #endregion

        #region 考勤
        private void ShowSalaryDetail()
        {
            TurnToAttPage(new SalaryDetailUI(), new SalaryDetailViewModel(ModelSource.SalaryDetails));
        }


        private AttendeceAnalysisUI _curAttendeceAnalysisUI;
        private AttendeceAnalysisViewModel _curAttendeceAnalysisViewModel;
        private void ShowAttendanceAnalysis()
        {
            if (_curAttendeceAnalysisUI == null || _curAttendeceAnalysisViewModel == null) {
                _curAttendeceAnalysisUI = new AttendeceAnalysisUI();
                _curAttendeceAnalysisViewModel = new AttendeceAnalysisViewModel(ModelSource.AttendanceResults);
            }
            TurnToAttPage(_curAttendeceAnalysisUI, _curAttendeceAnalysisViewModel);
        }

        private void TiaoXiuManage()
        {
            TurnToAttPage(new TiaoXiuManagerUI(), new TiaoXiuManagerViewModel(ModelSource.TiaoXius));
        }

        private void AttendanceManage()
        {
            TurnToAttPage(new AttendenceManagerUI(), new AttendenceManagerViewModel(ModelSource.Attendances));
        }

        private void ShowAskLeaveManageUI()
        {
            TurnToAttPage(new AskLeaveManagerUI(), new AskLeaveManagerViewModel(ModelSource.AskLeaves));
        }

        private void ShowOverWorkManageUI()
        {
            TurnToAttPage(new OverWorkManagerUI(), new OverWorkManagerViewModel(ModelSource.OverWorks));
        }

        private void ShowReSignInManageUI()
        {
            TurnToAttPage(new ReSignInManagerUI(), new ReSignInManagerViewModel(ModelSource.ReSignIns));
        }

        private void ShowBusinessTripManageUI()
        {
            TurnToAttPage(new BusinessTripManagerUI(), new BusinessTripManagerViewModel(ModelSource.BusinessTrips));
        }

        private void ShowWkarAsignUI()
        {
            TurnToAttPage(new WorkArrangementAsignUI(),
                new WorkArrangementAsignViewModel(ModelSource.AsignedArrangeWorks));
        }

        private void ShowWkarDefineUI()
        {
            TurnToAttPage(new WorkArrangementDefineUI(),
                new WorkArrangementDefineViewModel(ModelSource.DefinedArrangeWorks));
        }

        private void ShowVaccationSolutionUI()
        {
            TurnToAttPage(new VacationSolutionManagerUI(),
                new VacationSolutionManagerViewModel(ModelSource.DefVacationPlans));
        }

        private void ShowVaccationSolutionAsignUI()
        {
            TurnToAttPage(new VacationSolutionAsignUI(),
                new VacationSolutionAsignViewModel(ModelSource.AsignedVacationPlans));
        }

        private void CardFillRecordManage()
        {
            TurnToAttPage(new CardFillManagerUI(),
                new CardFillManagerViewModel(ModelSource.CardFillRecords));
        }

        private void TurnToAttPage(Control v, ViewModelBase vm)
        {
            v.DataContext = vm;
            IsAttTabItemSelected = true;
            Content = v;
            StatusConsole.WriteReady();
        }

        #endregion

        #region 人事管理
        private void ShowExpireTip()
        {
            int expiredCount = ModelSource.Employees.ToList().ConvertAll(e => e.ExpireDate)
                .Count(dateStr => DateTime.Now.GetDateSpanDays(dateStr) == 0);
            int expireNearCount = ModelSource.Employees.ToList().ConvertAll(e => e.ExpireDate)
                .Count(dateStr => DateTime.Now.GetDateSpanDays(dateStr) < ModelSource.ExpireRemindDaySpan) - expiredCount;
            if (expiredCount > 0 || expireNearCount > 0)
            {
                ExpireTipWindow w = new ExpireTipWindow();
                w.ExpiredCount = expiredCount;
                w.ExpireNearCount = expireNearCount;
                w.Show();
            }
        }

        private void ShowDormitoryManageUI()
        {
            TurnToHRPage(new DormitoryManagerUI(), new DormitoryManagerViewModel(ModelSource.Dormitories));
        }

        private void ShowOnJobManageUI()
        {
            TurnToHRPage(new OnJobManagerUI(), new OnJobManagerViewModel(ModelSource.Employees));
        }

        private void ShowOffJobManageUI()
        {
            TurnToHRPage(new OffJobManagerUI(), new OffJobManagerViewModel(ModelSource.Employees));
        }

        private void ShowOperatingPostManagerUI()
        {
            TurnToHRPage(new OperatingPostManagerUI(), new OperatingPostManagerViewModel(ModelSource.OperatingPosts));
        }

        private void ShowDepartmentManageUI()
        {
            TurnToHRPage(new DepartmentManagerUI(), new DepartmentManagerViewModel(ModelSource.Departments));
        }

        private void ShowEmployeeManageUI()
        {
            TurnToHRPage(new EmployeeManagerUI(), new EmployeeManagerViewModel(ModelSource.Employees));
        }

        private void ShowPostTransferManageUI()
        {
            TurnToHRPage(new PostTransferManagerUI(), new PostTransferManagerViewModel(ModelSource.EmployeePostAdjusts));
        }

        private void SalarySet()
        {
            TurnToHRPage(new BaseSalarySetUI(), new BaseSalarySetViewModel(ModelSource.Salarys));
        }

        private void TurnToHRPage(Control v, ViewModelBase vm)
        {
            v.DataContext = vm;
            IsHRTabItemSelected = true;
            Content = v;
            StatusConsole.WriteReady();
        }
        #endregion

        #region FLyout Content

        void IStatusConsole.ShowMessage(string msg)
        {
            StatusText = msg;
        }

        object IStatusConsole.ShowFlyout()
        {
            FLyoutContent = new DpSelectVM();
            Console.WriteLine("New FLyoutContent = DpSelectVM ");
            IsFlyoutOpen = true;
            Console.WriteLine("IsFlyoutOpen" + (IsFlyoutOpen ? "1" : "0"));
            return FLyoutContent;
        }

        void IStatusConsole.CloseFlyout()
        {
            IsFlyoutOpen = false;
        }

        #region IsFlyoutOpen 属性

        private bool _backfield_IsFlyoutOpen;

        public bool IsFlyoutOpen
        {
            get { return _backfield_IsFlyoutOpen; }
            set
            {
                _backfield_IsFlyoutOpen = value;
                RaisePropertyChanged(() => IsFlyoutOpen);
                if (!_backfield_IsFlyoutOpen)
                    FLyoutContent = null;
            }
        }

        #endregion


        #region FLyoutContent 属性

        private object _backfield_FLyoutContent;

        public object FLyoutContent
        {
            get { return _backfield_FLyoutContent; }
            set
            {
                _backfield_FLyoutContent = value;
                RaisePropertyChanged(() => FLyoutContent);
            }
        }

        #endregion

        #endregion

    }
}
