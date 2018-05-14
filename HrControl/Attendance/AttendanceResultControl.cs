using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Linq;
using System.Security.AccessControl;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class AttendanceResultControl : EntityControl<AttendanceResult>
    {

        class AskTypeList 
        {
            public float WithPay { get; set; }

            public float NoPay { get; set; }

        }

        protected override void InitLogNeed(AttendanceResult t)
        {
            ParaList.Clear();
            ParaList.Add("考勤分析结果");
        }

        protected override bool DeleteProtected(AttendanceResult t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
        }


        public bool Analysis(DateTime nowDateTime)
        {
            try
            {
                var employees = HrManagerContext.GetInstance().Employees.ToList();
                foreach (var employee in employees)
                {
                    var deleterange = HrManagerContext.GetInstance().AttendanceResults.Where(a => a.EmployeeNo == employee.EmployeeNO).ToList().Where(a => a.AttendanceDateMonth == nowDateTime.Month.ToString());
                    HrManagerContext.GetInstance().AttendanceResults.RemoveRange(deleterange);
                    var results = CalculateTime(employee, nowDateTime);
                    HrManagerContext.GetInstance().AttendanceResults.AddRange(results);
                    HrManagerContext.GetInstance().SaveChanges();
                }
                WageDetailControl wageDetail = new WageDetailControl();
                wageDetail.Analysis(nowDateTime);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
           
        }

        #region 数据处理

        private VacationPlan GetVactionPlans(Employee employee)
        {
            var vactionPlans = HrManagerContext.GetInstance().VacationPlans;
            if (vactionPlans.Any(v => v.EmployeeId == employee.Id))
                return vactionPlans.Where(v => v.EmployeeId == employee.Id).ToList()[0];
            if (vactionPlans.Any(v => v.OperatingPostId == employee.OperatingPostId))
                return vactionPlans.Where(v => v.DepartmentId == employee.DepartmentId).ToList()[0];
            if (vactionPlans.Any(v => v.DepartmentId == employee.DepartmentId))
                return vactionPlans.Where(v => v.DepartmentId == employee.DepartmentId).ToList()[0];
            return vactionPlans.ToList().Where(a => a.IsCommonDefine).ToList()[0];
        }

        private List<ArrangeWork> GetArrangeWorks(Employee employee)
        {
            var arrangeWorks = HrManagerContext.GetInstance().ArrangeWorks.ToList();
            var emparrangeWorks = arrangeWorks.Where(a => a.Employee == employee).ToList();
            if (emparrangeWorks.Count != 0) return emparrangeWorks;
            var operatarrangeWorks = arrangeWorks.Where(a => a.OperatingPost == employee.OperatingPost).ToList();
            if (operatarrangeWorks.Count != 0) return operatarrangeWorks;
            var departarrangeWorks = arrangeWorks.Where(a => a.Department == employee.Department).ToList();
            if (departarrangeWorks.Count != 0) return departarrangeWorks;
            return arrangeWorks.Where(a => a.IsCommonDefine).ToList();
        }



     
        

        public List<AttendanceResult> CalculateTime(Employee employee, DateTime now)
        {


            int i = 0;

            var attendanceResults = new List<AttendanceResult>();
            var arrageworks = GetArrangeWorks(employee).ToList();

            #region 获取一个月的数据

            var attendanceForMonth =
                HrManagerContext.GetInstance()
                    .Attendances.Where(a => a.EmployeeNo == employee.EmployeeNO)
                    .ToList()
                    .FindAll(a => a.RecordTimeToDateTime.Month == now.Month)
                    .ToList();


            var overWorkForMonth =
                HrManagerContext.GetInstance()
                    .OverWorks.Where(o => o.EmployeeId == employee.EmployeeId)
                    .ToList().FindAll(a => a.BeginDateTimeToDateTime.Month == now.Month).ToList();

            var businessTripsForMonth =
                HrManagerContext.GetInstance()
                    .BusinessTrips.Where(b => b.EmployeeId == employee.EmployeeId).ToList()
                    .FindAll(a => a.BeginDateToDateTime.Month == now.Month).ToList();

            var reSignInForMonth =
                HrManagerContext.GetInstance()
                    .ReSignIns.Where(r => r.EmployeeId == employee.EmployeeId)
                    .ToList()
                    .FindAll(a => a.ReSignInDateToDateTime.Month == now.Month)
                    .ToList();

            var askLeaveForMonth =
                HrManagerContext.GetInstance()
                    .AskLeaves.Where(a => a.EmployeeId == employee.EmployeeId)
                    .ToList()
                    .FindAll(a => a.BeginDateToDateTime.Month == now.Month)
                    .ToList();

            #endregion
            var WorkDays = new List<DateTimeExtend>();
            var LeaveDays = new List<DateTimeExtend>();
            var analysis = new AttendanceAnalysis();


            DetachMonthForWork(WorkDays, LeaveDays, now, employee);

            foreach (var workDay in WorkDays)
            {
               // Console.WriteLine("workday: " + i);
                i++;
               
                var attendanceToday = analysis.GetAttendanceToday(attendanceForMonth, overWorkForMonth,
                    businessTripsForMonth, reSignInForMonth, askLeaveForMonth, workDay.DateTime.Day);
                attendanceToday.Employee = employee;
                var aResult = new AttendanceResult();
                attendanceResults.Add(aResult);
                aResult.EmployeeName = employee.EmployeeBaseInfo.EmployName;
                aResult.EmployeeNo = employee.EmployeeNO;
                aResult.AttendanceDate = workDay.DateTime.ToString("d");

                var result = attendanceToday.AskleavesToDay.Count > 0 || attendanceToday.BusinessTripsToDay.Count > 0 || attendanceToday.OverWorksToday.Count > 0 || attendanceToday.AttendancesForDay.Count > 0;

                if (result)
                {
                    //处理出差、加班、请假,
                    processUnnormal(attendanceToday, aResult);
                    if (attendanceToday.AttendancesForDay.Count != 0)
                    {
                        var workListDate = new List<NearByDateTimeClass>();
                        attendanceToday = analysis.AnalysisForPresonByDay(attendanceToday, arrageworks);
                        var curArrageworks =
                            arrageworks.Where(a => a.ArrangeWorkNo == attendanceToday.ArrangeWorkNo).ToList();

                        if (curArrageworks.Count != 0)
                            aResult.BanCi = curArrageworks.First().WorkName;

                        //foreach (var work in curArrageworks)
                        //{
                        //    if (attendanceToday.AskleavesToDay.Exists(a => a.BeginDateToDateTime.Hour < work.OnDutyTimeToDateTime.Hour))
                        //        attendanceToday.VirAttendanceDateTimes.Add(new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OnDutyTimeToDateTime.Hour, work.OnDutyTimeToDateTime.Minute, 0));
                        //    if (attendanceToday.AskleavesToDay.Exists(a => a.BeginDateToDateTime.Hour < work.OffDutyTimeToDateTime.Hour))
                        //        attendanceToday.VirAttendanceDateTimes.Add(new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OffDutyTimeToDateTime.Hour, work.OffDutyTimeToDateTime.Minute, 0));
                        //    if (attendanceToday.BusinessTripsToDay.Exists(a => a.BeginDateToDateTime.Hour < work.OnDutyTimeToDateTime.Hour))
                        //        attendanceToday.VirAttendanceDateTimes.Add(new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OnDutyTimeToDateTime.Hour, work.OnDutyTimeToDateTime.Minute, 0));
                        //    if (attendanceToday.BusinessTripsToDay.Exists(a => a.BeginDateToDateTime.Hour < work.OffDutyTimeToDateTime.Hour))
                        //        attendanceToday.VirAttendanceDateTimes.Add(new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OffDutyTimeToDateTime.Hour, work.OffDutyTimeToDateTime.Minute, 0));
                        //}

                        workListDate = GetCorrectWorkList(attendanceToday.VirAttendanceDateTimes, curArrageworks);
                        var workList = workListDate.ConvertAll(w => !w.IsDispalyRecord() ? "" :w.Datetime.ToString("T"));
                        aResult.OnDutyMorning = workList[0];
                        aResult.OffDutyMorning = workList[1];
                        aResult.OnDutyNoon = workList[2];
                        aResult.OffDutyNoon = workList[3];
                        aResult.OnDutyNight = workList[4];
                        aResult.OffDutyNight = workList[5];

                        Action<NearByDateTimeClass, int> setAResult = delegate (NearByDateTimeClass duty, int worktype)
                        {
                            var resultint = duty.IsValidRecord(worktype);
                            if (resultint == 1)
                            {
                                aResult.KuanGongTimes += duty.Span;
                            }
                            if (resultint == 2)
                            {
                                aResult.ChiDaoTimes.Add(duty.Span);
                            }
                            if (resultint == 2)
                            {
                                aResult.ZaoTuiTimes.Add(duty.Span);
                            }

                        };

                        Action<NearByDateTimeClass, NearByDateTimeClass, ArrangeWork> Action1 = delegate (NearByDateTimeClass w1, NearByDateTimeClass w2, ArrangeWork work)
                         {
                             DateTime realonduty;
                             DateTime realOffduty;
                             if (w1.IsDispalyRecord())
                             {
                                 realonduty = w1.Datetime;
                                 setAResult(w1, 1);
                             }
                             else
                             {
                                 realonduty = new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OnDutyTimeToDateTime.Hour, work.OnDutyTimeToDateTime.Minute, 0);
                             }
                             if (w2.IsDispalyRecord())
                             {
                                 realOffduty = w2.Datetime;
                                 setAResult(w2, 2);
                             }
                             else
                             {
                                 realOffduty = new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OffDutyTimeToDateTime.Hour, work.OffDutyTimeToDateTime.Minute, 0);
                                 if (work.IsPassDayWork)
                                     realonduty = realonduty.AddDays(1);
                             }
                             aResult.normalWorkTime += realOffduty.Subtract(realonduty).TotalMinutes;
                         };


                        foreach (var work in curArrageworks)
                        {
                           
                            if (work.SpanType == ArrangeWorkTimeSpanType.Moning)
                            {
                                //if (workListDate[0].IsDispalyRecord())
                                //{
                                //    realonduty = workListDate[0].Datetime;
                                //    setAResult(workListDate[0], 1);
                                //}
                                //else
                                //{
                                //    realonduty = new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OnDutyTimeToDateTime.Hour, work.OnDutyTimeToDateTime.Minute, 0);
                                //}
                                //if (workListDate[1].IsDispalyRecord())
                                //{
                                //    realOffduty = workListDate[1].Datetime;
                                //    setAResult(workListDate[1], 2);
                                //}
                                //else
                                //{
                                //    realOffduty = new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OffDutyTimeToDateTime.Hour, work.OffDutyTimeToDateTime.Minute, 0);
                                //    if (work.IsPassDayWork)
                                //        realonduty = realonduty.AddDays(1);
                                //}
                                //aResult.normalWorkTime += realOffduty.Subtract(realonduty).TotalMinutes;
                                Action1(workListDate[0], workListDate[1], work);


                            }
                            else if (work.SpanType == ArrangeWorkTimeSpanType.Afternoon)
                            {
                                //if (workListDate[2].IsDispalyRecord())
                                //    setAResult(workListDate[2], 1);
                                //if (workListDate[3].IsDispalyRecord())
                                //    setAResult(workListDate[3], 2);
                                Action1(workListDate[2], workListDate[3], work);
                            }
                            else
                            {
                                //setAResult(workListDate[4], 1);
                                //if (workListDate[4].IsDispalyRecord())
                                //    setAResult(workListDate[5], 2);
                                //if (workListDate[5].IsDispalyRecord())
                                Action1(workListDate[4], workListDate[5], work);
                                //添加夜班次数
                                aResult.IsNightDuty = true;
                            }
                        }
                    }
                }
                else
                {
                    // 旷工一天
                    aResult.KuanGongTimes = 8;
                }
            }
            foreach (var workDay in LeaveDays)
            {

                //var attendanceToday = analysis.GetAttendanceToday(attendanceForMonth, overWorkForMonth,
                //    businessTripsForMonth, reSignInForMonth, askLeaveForMonth, leaveDay.DateTime.Day);
                //attendanceToday.Employee = employee;
                //var aResult = new AttendanceResult();
                //attendanceResults.Add(aResult);
                //aResult.EmployeeName = employee.EmployeeBaseInfo.EmployName;
                //aResult.EmployeeNo = employee.EmployeeNO;
                //aResult.AttendanceDate = leaveDay.DateTime.ToString("d");

                //var result = attendanceToday.AskleavesToDay.Count > 0 || attendanceToday.BusinessTripsToDay.Count > 0 || attendanceToday.OverWorksToday.Count > 0 || attendanceToday.AttendancesForDay.Count > 0;

                //if (result)
                //{
                //    if(leaveDay.type == DateTimeExtendtype.Holiday)
                //    {
                //        aResult.OverWork_voc = GetOverWork(attendanceToday);
                //    }
                //    else if(leaveDay.type == DateTimeExtendtype.WeeKendDay)
                //    {
                //        aResult.OverWork_weekend = GetOverWork(attendanceToday);
                //    }
                //    else
                //    {
                //        aResult.OverWork_normal = GetOverWork(attendanceToday);
                //    }
                //}


                var attendanceToday = analysis.GetAttendanceToday(attendanceForMonth, overWorkForMonth,
                      businessTripsForMonth, reSignInForMonth, askLeaveForMonth, workDay.DateTime.Day);
                attendanceToday.Employee = employee;
                var aResult = new AttendanceResult();
                attendanceResults.Add(aResult);
                aResult.EmployeeName = employee.EmployeeBaseInfo.EmployName;
                aResult.EmployeeNo = employee.EmployeeNO;
                aResult.AttendanceDate = workDay.DateTime.ToString("d");

                var result = attendanceToday.AskleavesToDay.Count > 0 || attendanceToday.BusinessTripsToDay.Count > 0 || attendanceToday.OverWorksToday.Count > 0 || attendanceToday.AttendancesForDay.Count > 0;

                if (result)
                {
                    //处理出差、加班、请假,
                    processUnnormal(attendanceToday, aResult);

                    if (workDay.type == DateTimeExtendtype.Holiday)
                    {
                        aResult.OverWork_voc = GetOverWork(attendanceToday);
                    }
                    else if (workDay.type == DateTimeExtendtype.WeeKendDay)
                    {
                        aResult.OverWork_weekend = GetOverWork(attendanceToday);
                    }
                    else
                    {
                        aResult.OverWork_normal = GetOverWork(attendanceToday);
                    }


                    if (attendanceToday.AttendancesForDay.Count != 0)
                    {
                        var workListDate = new List<NearByDateTimeClass>();
                        attendanceToday = analysis.AnalysisForPresonByDay(attendanceToday, arrageworks);
                        var curArrageworks =
                            arrageworks.Where(a => a.ArrangeWorkNo == attendanceToday.ArrangeWorkNo).ToList();
                        if (curArrageworks.Count != 0)
                            aResult.BanCi = curArrageworks.First().WorkName;



                        workListDate = GetCorrectWorkList(attendanceToday.VirAttendanceDateTimes, curArrageworks);
                        var workList = workListDate.ConvertAll(w => !w.IsDispalyRecord() ? "" : w.Datetime.ToString("T"));
                        aResult.OnDutyMorning = workList[0];
                        aResult.OffDutyMorning = workList[1];
                        aResult.OnDutyNoon = workList[2];
                        aResult.OffDutyNoon = workList[3];
                        aResult.OnDutyNight = workList[4];
                        aResult.OffDutyNight = workList[5];

                        Action<NearByDateTimeClass, int> setAResult = delegate (NearByDateTimeClass duty, int worktype)
                        {
                            var resultint = duty.IsValidRecord(worktype);
                            if (resultint == 1)
                            {
                                aResult.KuanGongTimes += duty.Span;
                            }
                            if (resultint == 2)
                            {
                                aResult.ChiDaoTimes.Add(duty.Span);
                            }
                            if (resultint == 2)
                            {
                                aResult.ZaoTuiTimes.Add(duty.Span);
                            }
                        };

                        Action<NearByDateTimeClass, NearByDateTimeClass, ArrangeWork> Action1 = delegate (NearByDateTimeClass w1, NearByDateTimeClass w2, ArrangeWork work)
                        {
                            DateTime realonduty;
                            DateTime realOffduty;
                            if (w1.IsDispalyRecord())
                            {
                                realonduty = w1.Datetime;
                                setAResult(w1, 1);
                            }
                            else
                            {
                                realonduty = new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OnDutyTimeToDateTime.Hour, work.OnDutyTimeToDateTime.Minute, 0);
                            }
                            if (w2.IsDispalyRecord())
                            {
                                realOffduty = w2.Datetime;
                                setAResult(w2, 2);
                            }
                            else
                            {
                                realOffduty = new DateTime(workDay.DateTime.Year, workDay.DateTime.Month, workDay.DateTime.Day, work.OffDutyTimeToDateTime.Hour, work.OffDutyTimeToDateTime.Minute, 0);
                                if (work.IsPassDayWork)
                                    realonduty = realonduty.AddDays(1);
                            }
                            aResult.normalWorkTime += realOffduty.Subtract(realonduty).TotalMinutes;
                        };


                        foreach (var work in curArrageworks)
                        {

                            if (work.SpanType == ArrangeWorkTimeSpanType.Moning)
                            {
                                Action1(workListDate[0], workListDate[1], work);

                            }
                            else if (work.SpanType == ArrangeWorkTimeSpanType.Afternoon)
                            {
                                Action1(workListDate[2], workListDate[3], work);
                            }
                            else
                            {
                                Action1(workListDate[4], workListDate[5], work);
                                //添加夜班次数
                                aResult.IsNightDuty = true;
                            }
                        }
                     
                     //   Console.WriteLine("levavDay " + i);
                        i++;

                    }
                }

            }
            return attendanceResults;
        }
        #region 获取正确的打卡时间

        private double GetOverWork(AttendanceToday attendanceToday)
        {
            double result = 0.0;
            int i = 0;
            var attendance = attendanceToday.AttendancesForDay.ConvertAll(a => a.RecordTimeToDateTime);
            attendance.Sort();
            while (i < attendanceToday.AttendancesForDay.Count)
            {
                try
                {
                    result += Math.Abs(attendance[i + 1].Subtract(attendance[i]).TotalMinutes);
                    i = i + 2;
                }
                catch { i = i + 2; }
              
            }
            i = 0;
            //while(i < attendanceToday.OverWorksToday.Count)
            //{
            //    result += attendanceToday.OverWorksToday[i].EndDateTimeToDateTime.Subtract(attendanceToday.OverWorksToday[i].BeginDateTimeToDateTime).TotalMinutes;
            //    i++;
            //}
            while (i < attendanceToday.BusinessTripsToDay.Count)
            {
                result += attendanceToday.BusinessTripsToDay[i].EndDateToDateTime.Subtract(attendanceToday.BusinessTripsToDay[i].BeginDateToDateTime).TotalMinutes;
                i++;
            }
            return result;
        }


        private NearByDateTimeClass NearByDateTime(DateTime realTime, List<DateTime> list)
        {
            var t1 = new DateTime(list[0].Year, list[0].Month, list[0].Day, realTime.Hour, realTime.Minute, list[0].Second);
            List<NearByDateTimeClass> spanList = new List<NearByDateTimeClass>();
            foreach (var item in list)
            {
                spanList.Add(new NearByDateTimeClass()
                {
                    Datetime = item,
                    Span = Math.Abs(item.Subtract(t1).TotalMinutes)
                });
            }
            spanList.Sort();
            return spanList.First();
       
        }

        private List<NearByDateTimeClass> GetCorrectWorkList(List<DateTime> list, List<ArrangeWork> curArrageworks)
        {


            List<NearByDateTimeClass> datatimes = new List<NearByDateTimeClass>();
            datatimes.Capacity = 6;
            for (int i = 0; i < 6; i++)
            {
                datatimes.Add(new NearByDateTimeClass());
            }
            //补实际上班时间
            foreach (var curArragework in curArrageworks)
            {
                switch (curArragework.SpanType)
                {
                    case ArrangeWorkTimeSpanType.Moning:
                        datatimes[0] = NearByDateTime(curArragework.OnDutyTimeToDateTime, list);
                        datatimes[1] = NearByDateTime(curArragework.OffDutyTimeToDateTime, list);
                        break;
                    case ArrangeWorkTimeSpanType.Afternoon:
                        datatimes[2] = NearByDateTime(curArragework.OnDutyTimeToDateTime, list);
                        datatimes[3] = NearByDateTime(curArragework.OffDutyTimeToDateTime, list);
                        break;
                    case ArrangeWorkTimeSpanType.Night:
                        datatimes[4] = NearByDateTime(curArragework.OnDutyTimeToDateTime, list);
                        datatimes[5] = NearByDateTime(curArragework.OffDutyTimeToDateTime, list);
                        break;
                }
            }
            return datatimes;
        }

        #endregion

        /// <summary>
        /// 处理出差时间 请假时间
        /// </summary>
        /// <param name="attendanceToday"></param>
        /// <param name="aResult"></param>
        private void processUnnormal(AttendanceToday attendanceToday, AttendanceResult aResult)
        {
            var groups = attendanceToday.AskleavesToDay.GroupBy(a => a.AskLeaveType.AskLeaveTypeId);
            foreach (var group in groups)
            {
                AskLeaveTypeForAttendance atfa = new AskLeaveTypeForAttendance();

                var askLeaveType = HrManagerContext.GetInstance().AskLeaveTypes.Find(group.Key);
                atfa.AskLeaveType = askLeaveType;
                foreach (var item in group)
                {
                    atfa.TimeCount += item.EndDateToDateTime.Subtract(item.BeginDateToDateTime).TotalHours;
                }
                aResult.AskLeaveTypeForAttendances.Add(atfa);
            }

            foreach (BusinessTrip tmp_bust in attendanceToday.BusinessTripsToDay)
            {
                aResult.BusTrip += tmp_bust.EndDateToDateTime.Subtract(tmp_bust.BeginDateToDateTime).TotalHours;
            }

            var tiaoxius =
                HrManagerContext.GetInstance()
                    .TiaoXius.Where(t => t.EmployeeId == attendanceToday.Employee.EmployeeId)
                    .ToList()
                    .Where(t => t.CurDateTime.Day == attendanceToday.Day)
                    .ToList();

            if (tiaoxius.Count != 0)
            {
                if (tiaoxius[0].IsHalfDay)
                {
                    aResult.TiaoXiu = "0.5";
                }
                else
                {
                    aResult.TiaoXiu = "1";
                }
            }
            else
            {
                aResult.TiaoXiu = "0";
            }


            //foreach (OverWork tmp_over in attendanceToday.OverWorksToday)
            //{
            //    aResult.OverWork_normal += double.Parse(tmp_over.ApplyTime);
            //}

            aResult.ReSignIn = attendanceToday.ReSiginToday.Count;

        }
    

        private void DetachMonthForWork(List<DateTimeExtend> workDays, List<DateTimeExtend> LeaveDays, DateTime now,Employee employee)
        {
              var vacation = GetVactionPlans(employee);
            int daycount = DateTime.DaysInMonth(now.Year, now.Month);
            DateTime begDateTime = new DateTime(now.Year,now.Month,1);
            DateTime endDateTime = new DateTime(now.Year, now.Month, daycount);
            while (begDateTime <= endDateTime)
            {
                if (vacation.VacationDays.Contains(begDateTime))
                {
                    LeaveDays.Add(new DateTimeExtend()
                    {
                        DateTime = begDateTime,
                        type = DateTimeExtendtype.Holiday
                    });
                }
                else if (vacation.Saturdays.Contains(begDateTime) ||
                         vacation.Sundays.Contains(begDateTime))
                {
                    LeaveDays.Add(new DateTimeExtend()
                    {
                        DateTime = begDateTime,
                        type = DateTimeExtendtype.WeeKendDay,
                    });
                }
                else
                {
                    workDays.Add(new DateTimeExtend()
                    {
                        DateTime = begDateTime,
                        type = DateTimeExtendtype.WorkDay,
                    });
                }
                begDateTime = begDateTime.AddDays(1);
            }

            var tiaoxius =
                HrManagerContext.GetInstance()
                    .TiaoXius.Where(t => t.EmployeeId == employee.EmployeeId ).ToList().Where(t=> t.CurDateTime.Month == now.Month).ToList();

            foreach (var tiaoxiu in tiaoxius)
            {
                var theholiDay = LeaveDays.Single(w => w.DateTime.Day == tiaoxiu.TiaoXiuDateTime.Day);
                var theDay = workDays.Single(w => w.DateTime.Day == tiaoxiu.CurDateTime.Day);
                if (!tiaoxiu.IsHalfDay)
                {
                    workDays.Remove(theDay);
                    workDays.Add(theholiDay);
                    LeaveDays.Remove(theholiDay);
                    theDay.type = theholiDay.type;
                    LeaveDays.Add(theDay);
                }

            }
        }

        #endregion
    }
}