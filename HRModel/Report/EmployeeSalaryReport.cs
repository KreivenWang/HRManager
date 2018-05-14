using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public class EmployeeSalaryReport : EmployeeReport
    {
        /*       年 月   工号 部门  姓名 职务  工日 底薪  岗位津贴 特岗津贴    高温津贴 特殊津贴    夜班津贴 工龄奖	"平时加班 (h)"	
         *       "平时 加班费"	"周日加班 (h)"	"周日加班费"	"节假日加班(h)"	"节假日加班费"	"病事假(h)"	"放假(h)"	"迟到/早退(次)"	
         *       "旷工(h)"	其它缺勤	工资合计	餐费	其它	"代扣税款"	社保费	话费	实发工资*/
        [Localize("年")]
        public string Year { get; set; }

        [Localize("月")]
        public string Month { get; set; }

        [Localize("工日")]
        public string WorkDay { get; set; }

        [Localize("底薪")]
        public string BaseSalary { get; set; }

        [Localize("岗位津贴")]
        public string PostAllowance { get; set; }

        [Localize("特岗津贴")]
        public string SpecialPostAllowance { get; set; }

        [Localize("高温津贴")]
        public string HighTemperatureAllowance { get; set; }

        [Localize("特殊津贴")]
        public string SpecialAllowance { get; set; }

        [Localize("夜班津贴")]
        public string NightWorkAllowance { get; set; }

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
