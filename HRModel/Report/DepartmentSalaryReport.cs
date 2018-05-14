using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public class DepartmentSalaryReport
    {
        /* 年 月   部门 人数  底薪 各种津贴    工龄奖 平时加班(h) 平时加班费	"周日加班(h)"	"周日加班费"	节假日加班	节假日加班费	
         * 缺勤（H)( 病事假 放假	"迟到（次）"	旷工	其它缺勤	)	
         * 工资合计	餐费	其它	"代扣税款"	社保费	话费	 实发工资			*/

        public Department Department { get; set; }

        [Localize("年")]
        public string Year { get; set; }

        [Localize("月")]
        public string Month { get; set; }

        [Localize("部门名称")]
        public string DepartName => Department?.DepartName;

        [Localize("人数")]
        public string DepartmentMemberCount => Department?.Employees?.Count.ToString();

        [Localize("底薪")]
        public string BaseSalary { get; set; }

        [Localize("各种津贴")]
        public string Allowance { get; set; }

        [Localize("工龄奖")]
        public string AgeAllowance { get; set; }

        [Localize("平时加班(h)")]
        public string NormalOverWork { get; set; }

        [Localize("平时加班费")]
        public string NormalOverWorkAllowance { get; set; }

        [Localize("周日加班(h)")]
        public string WeekendOverWork { get; set; }

        [Localize("周日加班费")]
        public string WeekendOverWorkAllowance { get; set; }
        [Localize("节假日加班(h)")]
        public string VacationOverWork { get; set; }
        [Localize("节假日加班费")]
        public string VacationOverWorkAllowance { get; set; }
        [Localize("病事假(h)")]
        public string AskLeave { get; set; }
        [Localize("放假(h)")]
        public string Vacation { get; set; }
        [Localize("旷工(h)")]
        public string Absenabsenteeism { get; set; }
        [Localize("迟到/早退(次)")]
        public string LateOnEarlyOffCount { get; set; }
        [Localize("其它缺勤")]
        public string OtherAbsence { get; set; }
        [Localize("工资合计")]
        public string TotalSalary { get; set; }
        [Localize("餐费")]
        public string MealAllowance { get; set; }
        [Localize("其它")]
        public string Other { get; set; }
        [Localize("代扣税款")]
        public string WithholdingTaxes { get; set; }
        [Localize("社保费")]
        public string SocialSecurityCost { get; set; }
        [Localize("话费")]
        public string PhoneCost { get; set; }
        [Localize("实发工资")]
        public string ActualSalary { get; set; }
    }
}
