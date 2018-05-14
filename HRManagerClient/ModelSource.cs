using HrControl;
using HrControl.RenShiControl;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HRManagerDataAccess;

namespace HRManagerClient
{
    class ModelSource
    {
        public static readonly int ExpireRemindDaySpan = 16;
        public static double WorkAreaHeight { get; private set; }
        public static double WorkAreaWidth { get; private set; }
        public static double ExpectedTipLeft { get; private set; }
        public static double ExpectedTipTop { get; private set; }
        public static double TipWidth { get; private set; }
        public static double TipHeight { get; private set; }

        public static EntityCollection<Employee> Employees { get; private set; }
        public static EntityCollection<Department> Departments { get; private set; }
        public static EntityCollection<Dormitory> Dormitories { get; private set; }
        public static EntityCollection<OperatingPost> OperatingPosts { get; private set; }
        public static EntityCollection<EmployeePostAdjust> EmployeePostAdjusts { get; private set; }

        public static EntityCollection<Salary> Salarys
        {
            get
            {
                var result = new EntityCollection<Salary>(new SalaryControl());
                foreach (var employee in Employees.Where(e => !result.ToList().Exists(r => r.Employee == e)))
                {
                    result.AddWithEntity(new Salary { Employee = employee });
                }
                return result;
            }
        }

        public static EntityCollection<ArrangeWork> AsignedArrangeWorks { get; private set; }
        public static EntityCollection<ArrangeWork> DefinedArrangeWorks { get; private set; }
        public static EntityCollection<ArrangeWork> ArrangeWorks { get; private set; }

        public static EntityCollection<VacationPlan> DefVacationPlans { get; private set; }
        public static EntityCollection<VacationPlan> AsignedVacationPlans { get; private set; }
        public static EntityCollection<VacationPlan> VacationPlans { get; private set; }

        public static EntityCollection<AskLeave> AskLeaves { get; private set; }
        public static EntityCollection<BusinessTrip> BusinessTrips { get; private set; }
        public static EntityCollection<ReSignIn> ReSignIns { get; private set; }
        public static EntityCollection<OverWork> OverWorks { get; private set; }
        public static EntityCollection<SystemArgument> SystemArguments { get; private set; }
        public static EntityCollection<AskLeaveType> AskLeaveTypes { get; private set; }
        public static EntityCollection<CardFillRecord> CardFillRecords { get; private set; }
        public static ObservableCollection<Attendance> Attendances { get; private set; }
        public static EntityCollection<AttendanceResult> AttendanceResults { get; private set; }
        public static EntityCollection<WageDetail> SalaryDetails { get; private set; }
        public static EntityCollection<TiaoXiu> TiaoXius { get; private set; }

        public static AttendanceArguControl AttArgControl { get; private set; }
        public static BaseSalaryControl BaseSalaryControl { get; private set; }
        public static TaxControl TaxControl { get; private set; }

        public static SystemUser CurrentUser { get; private set; }
        public static EntityCollection<SystemRole> SystemRoles { get; private set; }
        public static EntityCollection<SystemUser> SystemUsers { get; private set; }

        public static EntityCollection<Couple> Couples { get; private set; }

        #region 报表

        /// <summary>
        /// 人事档案资料报表
        /// </summary>
        public static ObservableCollection<EmployeeProfileReport> EmployeeProfileReports
        {
            get
            {
                var result = new ObservableCollection<EmployeeProfileReport>();
                foreach (var employee in Employees) {
                    result.Add(new EmployeeProfileReport {Employee = employee});
                }
                return result;
            }
        }

        /// <summary>
        /// 人事变动
        /// </summary>
        public static ObservableCollection<EmployeeTransferReport> EmployeeTransferReports
        {
            get
            {
                var result = new ObservableCollection<EmployeeTransferReport>();
                foreach (var employee in Employees)
                {
                    var adjusts =
                        HrManagerContext.GetInstance()
                            .EmployeePostAdjusts.Where(epa => epa.EmployeeId == employee.EmployeeId).OrderBy(epa=> epa.AdjustDateTime);

                    foreach (var adjust in adjusts)
                    {
                        result.Add(new EmployeeTransferReport
                        {
                            Employee = employee,
                            CurDepartment = adjust.CurDepartment?.DepartName,
                            CurPost = adjust.CurOperatingPost?.OperatingPostName,
                            PrevDepartment = adjust.PrevDepartment?.DepartName,
                            PrevPost = adjust.PrevOperatingPost?.OperatingPostName,
                            RankStatus = adjust.RankStatus.ToString(),
                            TransferTime = adjust.AdjustDateTime.ToString()
                        });
                    }
                   
                }
                return result;
            }
        }

        /// <summary>
        /// 员工考勤记录（明细）
        /// </summary>
        public static ObservableCollection<EmployeeDayAttendenceReport> EmployeeDayAttendenceReports
        {
            get
            {
                var result = new ObservableCollection<EmployeeDayAttendenceReport>();
                foreach (var employee in Employees)
                {
                    //员工某个月的所有考勤记录
                    //result.Add(new EmployeeDayAttendenceReport { EmployeeName = employee.EmployeeBaseInfo.EmployName, EmployeeNo = employee.EmployeeNO});
                    var attendanceFroResults =
                        HrManagerContext.GetInstance()
                            .AttendanceResults.Where(a => a.EmployeeNo == employee.EmployeeNO)
                            .ToList();
                    foreach (
                        var attendanceFroResult in
                            attendanceFroResults.ConvertAll(a => a as EmployeeDayAttendenceReport))
                    {
                        result.Add(attendanceFroResult);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// 月考勤记录统计报表
        /// </summary>
        public static ObservableCollection<EmployeeMonthAttendenceReport> EmployeeMonthAttendenceReports
        {
            get
            {
                var result = new ObservableCollection<EmployeeMonthAttendenceReport>();
                foreach (var employee in Employees) {
                    var newReport = new EmployeeMonthAttendenceReport {Employee = employee};
                    //填属性这个光荣的使命就决定是你了

                    result.Add(newReport);
                }
                return result;
            }
        }

        /// <summary>
        /// 薪资信息总表
        /// </summary>
        public static ObservableCollection<DepartmentSalaryReport> DepartmentSalaryReports
        {
            get
            {
                var result = new ObservableCollection<DepartmentSalaryReport>();
                foreach (var department in Departments) {
                    var newReport = new DepartmentSalaryReport {Department = department};
                    //填属性这个光荣的使命就决定是你了

                    result.Add(newReport);
                }
                return result;
            }
        }

        /// <summary>
        /// 薪资信息明细
        /// </summary>
        public static ObservableCollection<EmployeeSalaryReport> EmployeeSalaryReports
        {
            get
            {
                var result = new ObservableCollection<EmployeeSalaryReport>();
                foreach (var employee in Employees) {
                    var newReport = new EmployeeSalaryReport {Employee = employee};
                    //填属性这个光荣的使命就决定是你了

                    result.Add(newReport);
                }
                return result;
            }
        }

        #endregion


        public static void UpdateData()
        {
            //using (var dbContext = new HrManagerContext()) {
            //    dbContext.Database.CreateIfNotExists();
            //}

            Employees = new EntityCollection<Employee>(new EmployeeControl());
            Departments = new EntityCollection<Department>(new DepartmentControl());
            OperatingPosts = new EntityCollection<OperatingPost>(new OperatingPostControl());
            Dormitories = new EntityCollection<Dormitory>(new DormitoryControl());
            EmployeePostAdjusts = new EntityCollection<EmployeePostAdjust>(new EmployeePostAdjustControl());
            

            ArrangeWorks = new EntityCollection<ArrangeWork>(new ArrangeWorkControl());
            AsignedArrangeWorks = new EntityCollection<ArrangeWork>(new ArrangeWorkControl(), w => !w.IsCommonDefine);
            DefinedArrangeWorks = new EntityCollection<ArrangeWork>(new ArrangeWorkControl(), w => w.IsCommonDefine);

            VacationPlans = new EntityCollection<VacationPlan>(new VacationPlanControl());
            AsignedVacationPlans = new EntityCollection<VacationPlan>(new VacationPlanControl(), w => !w.IsCommonDefine);
            DefVacationPlans = new EntityCollection<VacationPlan>(new VacationPlanControl(), w => w.IsCommonDefine);

            AskLeaves  = new EntityCollection<AskLeave>(new AskLeaveControl());
            BusinessTrips = new EntityCollection<BusinessTrip>(new BusinessTripControl());
            ReSignIns = new EntityCollection<ReSignIn>(new ReSignInControl());
            OverWorks = new EntityCollection<OverWork>(new OverWorkControl());

            SystemArguments = new EntityCollection<SystemArgument>(new SystemArgumentControl());
            AskLeaveTypes = new EntityCollection<AskLeaveType>(new AskLeaveTypeControl());
            CardFillRecords = new EntityCollection<CardFillRecord>(new CardFillRecordControl());
            Attendances = new ObservableCollection<Attendance>(HrManagerContext.GetInstance().Attendances.ToList());
            AttendanceResults = new EntityCollection<AttendanceResult>(new AttendanceResultControl());
            TiaoXius = new EntityCollection<TiaoXiu>(new TiaoXiuControl());
            SalaryDetails = new EntityCollection<WageDetail>(new WageDetailControl());

            AttArgControl = new AttendanceArguControl();
            BaseSalaryControl = new BaseSalaryControl();
            TaxControl = new TaxControl();

            SystemRoles = new EntityCollection<SystemRole>(new SystemRoleControl());
            if (!SystemRoles.ToList().Exists(s => s.IsDefaultRole))
                SystemRoles.AddWithEntity(SystemRole.Default);

            SystemUsers = new EntityCollection<SystemUser>(new SystemUserControl());
            if (!SystemUsers.ToList().Exists(s => s.IsDefaultUser)) 
                SystemUsers.AddWithEntity(SystemUser.DefaultAdmin);

            Couples = new EntityCollection<Couple>(new CoupleControl());

            WorkAreaHeight = System.Windows.SystemParameters.WorkArea.Height;
            WorkAreaWidth = System.Windows.SystemParameters.WorkArea.Width;
            TipWidth = 300;
            TipHeight = 200;
            ExpectedTipLeft = WorkAreaWidth - TipWidth;
            ExpectedTipTop = WorkAreaHeight - TipHeight;
        }

        public static void ChangeAuthority(SystemUser newUser)
        {
            CurrentUser = newUser;
        }
    }
}
