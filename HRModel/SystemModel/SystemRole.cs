using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class SystemRole : ObservableObject, IViewNeededModel
    {
        public static readonly SystemRole Default = new SystemRole()
        {
            CreateTime = DateTime.Now.ToString(),
            Name = "超级管理员",
            Enabled_SystemUser = true,
            Enabled_CardFill = true,
            Enabled_AskLeave = true,
            Enabled_AttArgs = true,
            Enabled_BusinessTrip = true,
            Enabled_EmployeeTransfer = true,
            Enabled_BaseSalaryArgs = true,
            Enabled_Department = true,
            Enabled_Dormitory = true,
            Enabled_EmployeeInfo = true,
            Enabled_EmployeeOffJob = true,
            Enabled_EmployeeOnJob = true,
            Enabled_OverWork = true,
            Enabled_Post = true,
            Enabled_ReSignIn = true,
            Enabled_SystemArgs = true,
            Enabled_SystemRole = true,
            Enabled_VacationAsign = true,
            Enabled_VacationPlan = true,
            Enabled_WorkArrangementAsign = true,
            Enabled_WorkArrangementDefine = true,
            IsActive = true,
            IsDefaultRole = true
        };

        public int Id
        {
            get { return SystemRoleId; }
        }

        public int SystemRoleId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        public bool IsDefaultRole { get; private set; }

        #region Authority

        public bool Enabled_CardFill { get; set; }
        public bool Enabled_Department { get; set; }
        public bool Enabled_AskLeave { get; set; }
        public bool Enabled_BusinessTrip { get; set; }
        public bool Enabled_ReSignIn { get; set; }
        public bool Enabled_OverWork { get; set; }
        public bool Enabled_EmployeeInfo { get; set; }
        public bool Enabled_EmployeeOnJob { get; set; }
        public bool Enabled_EmployeeOffJob { get; set; }
        public bool Enabled_EmployeeTransfer { get; set; }
        public bool Enabled_Dormitory { get; set; }
        public bool Enabled_Post { get; set; }
        public bool Enabled_AttArgs { get; set; }
        public bool Enabled_BaseSalaryArgs { get; set; }
        public bool Enabled_SystemArgs { get; set; }
        public bool Enabled_VacationPlan { get; set; }
        public bool Enabled_VacationAsign { get; set; }
        public bool Enabled_WorkArrangementDefine { get; set; }
        public bool Enabled_WorkArrangementAsign { get; set; }
        public bool Enabled_SystemRole { get; set; }
        public bool Enabled_SystemUser { get; set; }

        #endregion

    }
}
