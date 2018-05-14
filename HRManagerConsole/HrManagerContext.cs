using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using HRModel;

namespace HRManagerDataAccess
{
    public class HrManagerContext : DbContext
    {
        private static HrManagerContext entity;
        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 员工基础信息
        /// </summary>
        public DbSet<EmployeeBaseInfo> EmployeeBaseInfos { get; set; }

        /// <summary>
        /// 员工岗位调动记录
        /// </summary>
        public DbSet<EmployeePostAdjust> EmployeePostAdjusts { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// 考勤
        /// </summary>
        public DbSet<Attendance> Attendances { get; set; }

        /// <summary>
        /// 薪资
        /// </summary>
        public DbSet<Salary> Salarys { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>

        public DbSet<OperatingPost> OperatingPosts { get; set; }

        /// <summary>
        /// 宿舍
        /// </summary>
        public DbSet<Dormitory> Dormitorys { get; set; }

        /// <summary>
        /// 排班
        /// </summary>
        public DbSet<ArrangeWork> ArrangeWorks { get; set; }

        /// <summary>
        /// 加班
        /// </summary>
        public DbSet<OverWork> OverWorks { get; set; }

        /// <summary>
        /// 系统参数
        /// </summary>
        public DbSet<SystemArgument> SystemArguments { get; set; }
        public DbSet<AskLeaveType> AskLeaveTypes { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<SystemRole> SystemRoles { get; set; }

        /// <summary>
        /// 假期
        /// </summary>
        public DbSet<VacationPlan> VacationPlans { get; set; }

        /// <summary>
        /// 请假
        /// </summary>
        public DbSet<AskLeave> AskLeaves { get; set; }
        public DbSet<BusinessTrip> BusinessTrips { get; set; }
        public DbSet<ReSignIn> ReSignIns { get; set; }
        public DbSet<AttendanceResult> AttendanceResults { get; set; }

        /// <summary>
        /// 补卡
        /// </summary>
        public DbSet<CardFillRecord> CardFillRecords { get; set; }

        public DbSet<TiaoXiu> TiaoXius { get; set; }
        public DbSet<Couple> Couples { get; set; }


        public DbSet<WageDetail> WageDetails { get; set; }

        public static HrManagerContext GetInstance()
        {
            if(entity == null)
                entity = new HrManagerContext();
            return entity;
        }

        public static DbSet<T> GetDbSetInstance<T>()
            where T : class
        {
            if (entity == null)
                entity = new HrManagerContext();
            var propInfo = typeof(HrManagerContext).GetProperty(typeof(T).Name + "s");
            return (DbSet<T>)propInfo.GetValue(entity, null);
        }
    }
}
