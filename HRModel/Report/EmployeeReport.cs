using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public abstract class EmployeeReport : IEmployeeReport
    {
        public Employee Employee { get; set; }

        [Localize("工号")]
        public string EmployeeNo => Employee?.EmployeeNO;

        [Localize("姓名")]
        public string EmployeeName => Employee?.EmployeeBaseInfo?.EmployName;

        [Localize("部门")]
        public string DepartName => Employee?.Department?.DepartName;

        [Localize("岗位")]
        public string OperatingPostName => Employee?.OperatingPost?.OperatingPostName;

    }

    public interface IEmployeeReport
    {
        string EmployeeName { get; }
        string EmployeeNo { get; }
    }
}
