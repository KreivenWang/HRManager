using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public class EmployeeMonthAttendenceReport : EmployeeReport
    {
        [Localize("平日加班小时")]
        public string WorkDayOverWorkHour { get; set; }

        [Localize("周末加班小时")]
        public string WeekendOverWorkHour { get; set; }

        [Localize("假日加班小时")]
        public string VacationOverWorkHour { get; set; }

        [Localize("放假")]
        public string Vacation { get; set; }

        [Localize("调休")]
        public string TiaoXiu { get; set; }

        [Localize("病假")]
        public string SickLeave { get; set; }

        [Localize("迟到次数")]
        public string LateCount { get; set; }

        [Localize("补卡次数")]
        public string CardFillCount { get; set; }

        [Localize("旷工")]
        public string Absenteeism { get; set; }

        [Localize("补签")]
        public string ReSignIn { get; set; }
    }
}
