using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public enum SalaryType
    {
        [Localize("时薪")]
        MonthSalary,
        [Localize("月薪加时薪1")]
        MonthPlusHourSalary1,
        [Localize("月薪加时薪2")]
        MonthPlusHourSalary2
    }


    /// <summary>
    /// 薪资
    /// </summary>
    public class Salary : IViewNeededModel
    {
        public int SalaryId { get; set; }

        /// <summary>
        /// 底薪
        /// </summary>
        public float BasicSalary { get; set; }
        /// <summary>
        /// 岗位津贴
        /// </summary>
        public float PostAllowance { get; set; }

        public virtual Employee Employee { get; set; }

        public int? EmployeeId { get; set; }

        public SalaryType SalaryType { get; set; }

        /// <summary>
        /// 是否有日加班限制
        /// </summary>
        public bool HaveOverWorkLimitForDay { get; set; }

        public int LimitHourForDay { get; set; }

        /// <summary>
        /// 是否有月加班限制
        /// </summary>
        public bool HaveOverWorkLimitForMonth { get; set; }

        public int LimitHourForMonth { get; set; }

        int IViewNeededModel.Id
        {
            get { return SalaryId; }
        }

        public Salary()
        {
            
        }

    }

  
}
