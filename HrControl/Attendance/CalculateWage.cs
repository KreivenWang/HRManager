using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;


namespace HrControl
{
    public class CalculateWage
    {
        public class OverWorkList
        {
            public double overwork_normal_month { get; set; }
            public double overwork_weekend_month { get; set; }
            public double overwork_voc_month { get; set; }
        }
        public List<WageDetail> getWages(DateTime nowDateTime)
        {
            List<WageDetail> wages = new List<WageDetail>();
         //   AttendanceResultControl arc = new AttendanceResultControl();
            var employees = HrManagerContext.GetInstance().Employees.ToList();
            foreach (var employee in employees)
            {
                //这些加班的参数在 attendanceresult 里面就有 
                OverWorkList owl = new OverWorkList();
                int yebanjintienum = 0;
                int gongLingJiShu = 0;
                double tiaoxu_time = 0;
                double normal_work_time = 0;
                double askLeave_nopay = 0;
                double absenteeismTime = 0;
                //夫妻取值
                var couple = HrManagerContext.GetInstance().Couples.ToList().Where(a => a.EmployeeNan.Id == employee.EmployeeId || a.EmployeeNv.Id == employee.EmployeeId).ToList();
                List<AttendanceResult> tmp_nanResult = new List<AttendanceResult>();
                List<AttendanceResult> tmp_nvResult = new List<AttendanceResult>();
                if (couple.Count != 0)
                {
                    var no1 = couple[0].EmployeeNan.EmployeeNO;
                    var no2 = couple[0].EmployeeNv.EmployeeNO;
                    tmp_nanResult = HrManagerContext.GetInstance().AttendanceResults.Where(a => a.EmployeeNo == no1).ToList().Where(a => DateTime.Parse(a.AttendanceDate).Month == nowDateTime.Month).ToList();
                    tmp_nvResult = HrManagerContext.GetInstance().AttendanceResults.Where(a => a.EmployeeNo == no2).ToList().Where(a => DateTime.Parse(a.AttendanceDate).Month == nowDateTime.Month).ToList();
                }         
                int ccount = 0;
                double couple_work_time = 0;
                
                var results = HrManagerContext.GetInstance().AttendanceResults.Where(a => a.EmployeeNo == employee.EmployeeNO).ToList().Where(a => DateTime.Parse(a.AttendanceDate).Month == nowDateTime.Month).ToList();
                var salay = HrManagerContext.GetInstance().Salarys.Single(s => s.EmployeeId == employee.EmployeeId);
                var base_salay = BaseSalary.GetInstance();
                int ChiDaoKouXin = 0;
                double ZaoTuiTimeTotal = 0;
                foreach (var result in results)
                {
                    // 夫妻津贴处理
                    if (tmp_nanResult.Count > 0 && tmp_nvResult.Count > 0)
                    {
                        if (tmp_nanResult[ccount].normalWorkTime - tmp_nvResult[ccount].normalWorkTime >= 0)
                        {
                            couple_work_time += tmp_nvResult[ccount].normalWorkTime;
                        }
                        else
                        {
                            couple_work_time += tmp_nvResult[ccount].normalWorkTime;
                        }
                    }                 

                    foreach(double zaoTui in result.ZaoTuiTimes)
                    {
                        ZaoTuiTimeTotal += zaoTui/60;
                    }

                    if (result.IsNightDuty)
                    {
                        if (result.normalWorkTime >= 8)
                        {
                            // 若为夜班且考勤满8小时，则夜班津贴次数加1
                            yebanjintienum++;
                        }
                    }

                    // 迟到处理
                    int tmp_cnt = 0;
                    tmp_cnt += result.ChiDaoTimesCount;
                    foreach (double times in result.ChiDaoTimes)
                    {
                        if (tmp_cnt <= 3)
                        {
                            if (times <= 15)
                            {
                                ChiDaoKouXin += 5;
                            }
                            else if (times > 15 && times <= 30)
                            {
                                ChiDaoKouXin += 10;
                            }
                            else
                            { }
                        }
                        else
                        {
                            if (times <= 15)
                            {
                                ChiDaoKouXin += 10;
                            }
                            else if (times > 15 && times <= 30)
                            {
                                ChiDaoKouXin += 20;
                            }
                            else
                            { }
                        }
                    }

                    // 计算工龄是6的几倍
                    int years = result.AttendanceDateToDatetime.Year - DateTime.Parse(employee.HireDate).Year;
                    int months = years * 12 + result.AttendanceDateToDatetime.Month - DateTime.Parse(employee.HireDate).Month;
                    if (months % 6 == 0)
                    {
                        gongLingJiShu = months / 6;
                    }

                    // 加班特殊处理
                    if (employee.EmployeeBaseInfo.EmployName == "屈志勇" ||
                        employee.EmployeeBaseInfo.EmployName == "万正新" ||
                        employee.EmployeeBaseInfo.EmployName == "万松鹤")
                    {
                        if (result.OverWork_normal >= 120)
                        {
                            result.OverWork_normal = 120;
                        }
                        if (result.OverWork_weekend >= 600)
                        {
                            result.OverWork_weekend = 600;
                        }
                    }
                    owl.overwork_normal_month += result.OverWork_normal/60;
                    owl.overwork_weekend_month += result.OverWork_weekend/60;
                    owl.overwork_voc_month += result.OverWork_voc/60;
                    
                    tiaoxu_time += Convert.ToDouble(result.TiaoXiu)*8;

                    // 满8小时为一个工日
                    normal_work_time += result.normalWorkTime/60;

                    if (result.AskLeaveTypeForAttendances.Count > 0)
                    {
                        foreach (var tmp_res in result.AskLeaveTypeForAttendances)
                        {
                            if (!tmp_res.AskLeaveType.IsWithPay)
                            {
                                askLeave_nopay += tmp_res.TimeCount/60;
                            }
                            else
                            {
                                normal_work_time += tmp_res.TimeCount/60;
                            }
                        }
                    } 

                    // 产假特殊处理

                    absenteeismTime += result.KuanGongTimes/60;

                }
                if (salay.HaveOverWorkLimitForMonth)
                {
                    if (owl.overwork_normal_month >= 42)
                    {
                        owl.overwork_normal_month = 42;
                    }
                    if (owl.overwork_weekend_month >= 40)
                    {
                        owl.overwork_weekend_month = 40;
                    }
                    if (owl.overwork_voc_month >= 40)
                    {
                        owl.overwork_voc_month = 40;
                    }
                }
                wages.Add(CalculateWageForPerson(employee, owl, salay, base_salay, tiaoxu_time, normal_work_time, askLeave_nopay, absenteeismTime, yebanjintienum, gongLingJiShu, ChiDaoKouXin, ZaoTuiTimeTotal, couple_work_time));
                ccount++;
            }
            return wages;
        }
        private WageDetail CalculateWageForPerson(Employee employee, OverWorkList owl, Salary salary, BaseSalary base_salary, double tiaoxiu_time, double normal_work_time, double askLeave_nopay, double absenteeismTime, int yebanjintienum, int gongLingJiShu, int ChiDaoKouXin, double ZaoTuiTimeTotal, double couple_work_time)
        {
            WageDetail wage = new WageDetail();

            wage.Employee = employee;
            wage.EmployeeId = employee.EmployeeId;

            #region 计算加班费
            double tmp_result = tiaoxiu_time - owl.overwork_weekend_month;
            if (tmp_result <= 0)
            {
                owl.overwork_weekend_month = System.Math.Abs(tmp_result);
            }
            else
            {
                tmp_result = tmp_result - owl.overwork_normal_month;
                if (tmp_result <= 0)
                {
                    owl.overwork_weekend_month = 0;
                    owl.overwork_normal_month = System.Math.Abs(tmp_result);
                }
                else
                {
                    owl.overwork_weekend_month = 0;
                    owl.overwork_normal_month = 0;
                    tiaoxiu_time = tmp_result;
                }
            }
            double overwork_wage_normal = 0;
            double overwork_wage_weekend = 0;
            double overwork_wage_voc = 0;
            overwork_wage_normal = salary.BasicSalary / 21.75 / 8 * 1.5 * owl.overwork_normal_month;

            overwork_wage_weekend = salary.BasicSalary / 21.75 / 8 * 2 * owl.overwork_weekend_month;

            overwork_wage_voc = salary.BasicSalary / 21.75 / 8 * 3 * owl.overwork_voc_month;
            #endregion
            wage.jiaBanWage = overwork_wage_normal + overwork_wage_weekend + overwork_wage_voc;

            #region 计算工日
            normal_work_time = (normal_work_time - tiaoxiu_time - askLeave_nopay) / 8;
            double normalWage = 0;
            if (salary.SalaryType == SalaryType.MonthSalary)
            {
                normalWage = ((salary.BasicSalary + salary.PostAllowance) / 21.75) * normal_work_time;
            }
            else if (salary.SalaryType == SalaryType.MonthPlusHourSalary1)
            {
                normalWage = ((salary.BasicSalary + salary.PostAllowance - 1130 - 1150) / 21.75) * normal_work_time;
            }
            else if (salary.SalaryType == SalaryType.MonthPlusHourSalary2)
            {
                normalWage = ((salary.BasicSalary + salary.PostAllowance - 1130) / 21.75) * normal_work_time;
            }
            
            #endregion
            // 夜班津贴计算
            base_salary.NightAllowance = yebanjintienum * 3;

            // 夫妻津贴计算
            base_salary.CoupleAllowance = base_salary.CoupleAllowance / 21.75 * couple_work_time;

            // 环境津贴计算
            base_salary.EnvironmentalAllowance = base_salary.EnvironmentalAllowance / 21.75 * normal_work_time;

            // 高温津贴计算
            base_salary.GaoWenAllowance = 150 / 21.75 * normal_work_time;

            // 工龄津贴计算
            base_salary.WorkAgeAllowance = (base_salary.WorkAgeAllowance * gongLingJiShu) / 21.75 * normal_work_time;
            if (base_salary.WorkAgeAllowance >= base_salary.WorkAgeAllowanceMax)
            {
                base_salary.WorkAgeAllowance = base_salary.WorkAgeAllowanceMax;
            }

            // 旷工扣费计算
            wage.kuangGongKouFei = (salary.BasicSalary + salary.PostAllowance) / 21.75 * 3 * (absenteeismTime/8);

            // 津贴计算
            wage.jinTieWage = base_salary.NightAllowance + base_salary.EnvironmentalAllowance + base_salary.WorkAgeAllowance 
                + base_salary.TotalOnDutyAllowance + base_salary.SpecialPostAllowance + base_salary.CoupleAllowance;

            //ChiDaoKouXin 迟到扣薪
            //早退计算
            wage.zaoTuiKouFei = (salary.BasicSalary + salary.PostAllowance)/21.75/8/60*ZaoTuiTimeTotal*3;

            wage.chiDaoKouFei = ChiDaoKouXin;

            // 扣除旷工，迟到，早退，请假
            double act_wage = normalWage - wage.kuangGongKouFei - wage.chiDaoKouFei - wage.zaoTuiKouFei + wage.jiaBanWage + wage.jinTieWage;

           // 代扣税计算
           Tax tax = Tax.GetInstance();
            if (act_wage > tax.CutOffRule)
            {
                wage.geRenSuoDeShui = (act_wage - tax.Threshold - base_salary.SocialSecurity) * tax.OverCutOffRuleRatio - tax.FixedValue;
            }
            else
            {
                wage.geRenSuoDeShui = (act_wage - tax.Threshold - base_salary.SocialSecurity) * tax.UnderCutOffRuleRatio - tax.FixedValue;
            }

            // 公积金计算
            wage.gongJiJinKouFei = act_wage * tax.PresonRatio;


            // 最终所得工资( 社保、花费、餐费、其他扣款、津贴）
            act_wage = act_wage + base_salary.BoardWages + base_salary.PhoneCost - base_salary.SocialSecurity - base_salary.OtherDeductions - wage.geRenSuoDeShui - wage.gongJiJinKouFei;
            wage.shiJiGongZi = act_wage;

            return wage;
        }
    }
}
