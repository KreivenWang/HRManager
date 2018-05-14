using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public class WageDetail : IViewNeededModel
    {
        [Localize("员工")]
        public string EmployeeInfo
        {
            get
            {
                return Employee == null ? null : string.Format("[{0}]{1}", Employee.EmployeeNO, Employee.EmployeeBaseInfo.EmployName);
            }
        }
        [Localize("加班工资")]
        public double jiaBanWage { get; set; }
        [Localize("迟到扣费")]
        public int chiDaoKouFei { get; set; }
        [Localize("早退扣费")]
        public double zaoTuiKouFei { get; set; }
        [Localize("请假扣费")]
        public double qingJiaKouFei { get; set; }
        [Localize("旷工扣费")]
        public double kuangGongKouFei { get; set; }
        [Localize("公积金")]
        public double gongJiJinKouFei { get; set; }
        [Localize("个人所得税")]
        public double geRenSuoDeShui { get; set; }
        [Localize("津贴")]
        public double jinTieWage { get; set; }
        [Localize("实际工资")]
        public double shiJiGongZi { get; set; }
        public Employee Employee { get; set; }
        

        public int? EmployeeId { get; set; }


        public int WageDetailId { get; set; }

        public int Id
        {
            get
            {
                return WageDetailId;
            }
        }
    }
}
