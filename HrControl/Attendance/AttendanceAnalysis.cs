using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class AttendanceAnalysis
    {
        public TimeSpan GetTimeSpan(DateTime attendanceTime, DateTime arrangeWorkTime)
        {
            var d1 = new DateTime(attendanceTime.Year, attendanceTime.Month, attendanceTime.Day, arrangeWorkTime.Hour,
                arrangeWorkTime.Minute, arrangeWorkTime.Minute);
            if (d1 > attendanceTime)
                return d1.Subtract(attendanceTime);
            return attendanceTime.Subtract(d1);
        }




        /// <summary>
        ///     获取一天的值,传入一个月的值
        /// </summary>
        /// <param name="attendances"></param>
        /// <param name="overWorks"></param>
        /// <param name="businessTrips"></param>
        /// <param name="reSignIns"></param>
        /// <param name="askLeaves"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public AttendanceToday GetAttendanceToday(List<Attendance> attendances,
            List<OverWork> overWorks,
            List<BusinessTrip> businessTrips, List<ReSignIn> reSignIns, List<AskLeave> askLeaves, int day)
        {
            var attendanceForDay = attendances.Where(a => DateTime.Parse(a.RecordTime).Day == day).ToList();


            var overWorkForDay = overWorks.Where(o => DateTime.Parse(o.BeginDateTime).Day == day).ToList();


            var businessTripsForDay = businessTrips.Where(b => DateTime.Parse(b.BeginDate).Day == day).ToList();


            var reSignInForDay = reSignIns.Where(r => DateTime.Parse(r.ReSignInDate).Day == day).ToList();


            var askLeaveForDay = askLeaves.Where(a => DateTime.Parse(a.BeginDate).Day == day).ToList();

            var attendanceToDay = new AttendanceToday
            {
                Day =  day,
                AskleavesToDay = askLeaveForDay,
                BusinessTripsToDay = businessTripsForDay,
                OverWorksToday = overWorkForDay,
                ReSiginToday = reSignInForDay.ConvertAll(r => r.ReSignInDateToDateTime),
                AttendancesForDay = attendanceForDay
            };
            return attendanceToDay;
        }


        private bool IsInSpanTime(DateTime d1, DateTime d2,int limit)
        {
            return Math.Abs(d1.Subtract(d2).TotalMinutes) <= limit;
        }


        public AttendanceToday   AnalysisForPresonByDay(AttendanceToday aToday, List<ArrangeWork> arrangeWorks)
        {
            //这一天的数据

            var attendanceForDay = aToday.AttendancesForDay;

            var overWorkForDay = aToday.OverWorksToday;

            var businessTripsForDay = aToday.BusinessTripsToDay;

            var reSignInForDay = aToday.ReSiginToday;
            var askLeaveForDay = aToday.AskleavesToDay;


            var toDayAttendanceList = attendanceForDay.ConvertAll(a => a.RecordTimeToDateTime);


            //排除请假 出差 加班等影响的打卡记录
            aToday.VirAttendanceDateTimes = toDayAttendanceList.ToList();

            #region 这一天的打卡记录模拟

            //这一天的打开记录


            if (toDayAttendanceList.Count != 0)
            {

                //请假单 和 出差单 都会影响正常打卡 且推导不出正常的打卡 从打卡记录里面删除

                foreach (var askLeave in askLeaveForDay)
                {

                    toDayAttendanceList.RemoveAll(t => IsInSpanTime(t, askLeave.BeginDateToDateTime, 10));
                    toDayAttendanceList.RemoveAll(t => IsInSpanTime(t, askLeave.EndDateToDateTime, 10));

                }

                foreach (var businessTrip in businessTripsForDay)
                {

                    toDayAttendanceList.RemoveAll(t => IsInSpanTime(t, businessTrip.BeginDateToDateTime, 10));
                    toDayAttendanceList.RemoveAll(t => IsInSpanTime(t, businessTrip.EndDateToDateTime, 10));

                }




                foreach (var overworke in overWorkForDay)
                {
                    if (overworke.IsOffDuty)
                    {
                        toDayAttendanceList.Add(overworke.BeginDateTimeToDateTime);
                    }
                    else if (overworke.IsOnDuty)
                    {
                        toDayAttendanceList.Add(overworke.EndDateTimeToDateTime);
                    }
                    else
                    {
                        toDayAttendanceList.RemoveAll(t => IsInSpanTime(t, overworke.BeginDateTimeToDateTime, 20));
                        toDayAttendanceList.RemoveAll(t => IsInSpanTime(t, overworke.EndDateTimeToDateTime, 20));
                    }
                }
                toDayAttendanceList.AddRange(reSignInForDay);
            }
            else
            {
                return aToday;
            }

            #endregion


            if (toDayAttendanceList.Count() == 0) return aToday;

            var workTimeSpans = new List<WorkTimeSpan>();



            foreach (var dateTime in toDayAttendanceList)
            {
                //求每一个打卡时间与所有班次的时间差
                foreach (var arrangeWork in  arrangeWorks)
                {
                    workTimeSpans.Add(new WorkTimeSpan
                    {
                        OnDutyTimeSpan = GetTimeSpan(dateTime, arrangeWork.OnDutyTimeToDateTime),
                        OffDutyTimeSpan = GetTimeSpan(dateTime, arrangeWork.OffDutyTimeToDateTime),
                        ArrangeWorkNo = arrangeWork.ArrangeWorkNo
                    });
                }
            }


           

            //时间少的在前面
            workTimeSpans.Sort();
            var top10WorkTimeSpans = workTimeSpans.Take(20).ToList();
            var groups = top10WorkTimeSpans.GroupBy(t => t.ArrangeWorkNo);
            var countMax = groups.Max(g => g.Count());
            var MaxGroups = groups.Where(g => g.Count() == countMax).ToList();

            Dictionary<string, TimeSpan> gTimeSpans = new Dictionary<string, TimeSpan>();

            foreach (var maxGroup in MaxGroups)
            {
                var timeSpan = new TimeSpan();
                timeSpan = maxGroup.Aggregate(timeSpan, (current, span) => current + span.ComperTimeSpan);
                gTimeSpans.Add(maxGroup.Key, timeSpan);
            }
            var newdic = gTimeSpans.OrderBy(g => g.Value);
            aToday.ArrangeWorkNo = newdic.First().Key;
            return aToday;
        }


        //private List<ArrangeWork> GetArrangeWorks(Employee employee)
        //{
        //    var arrangeWorks = HrManagerContext.GetInstance().ArrangeWorks.ToList();
        //    employee.Department = new Department();
        //    employee.OperatingPost = new OperatingPost();

        //    var emparrangeWorks = arrangeWorks.Where(a => a.Employee == employee).ToList();
        //    if (emparrangeWorks.Count != 0) return emparrangeWorks;
        //    var operatarrangeWorks = arrangeWorks.Where(a => a.OperatingPost == employee.OperatingPost).ToList();
        //    if (operatarrangeWorks.Count != 0) return operatarrangeWorks;
        //    var departarrangeWorks = arrangeWorks.Where(a => a.Department == employee.Department).ToList();
        //    if (departarrangeWorks.Count != 0) return departarrangeWorks;
        //    return arrangeWorks.Where(a => a.IsCommonDefine).ToList();


        //}

        private class WorkTimeSpan : IComparable
        {
            public TimeSpan OnDutyTimeSpan { get; set; }

            public TimeSpan OffDutyTimeSpan { get; set; }

            public string ArrangeWorkNo { get; set; }


            public TimeSpan ComperTimeSpan
            {
                get { return OnDutyTimeSpan < OffDutyTimeSpan ? OnDutyTimeSpan : OffDutyTimeSpan; }
            }


            public int CompareTo(object obj)
            {
                return ComperTimeSpan.CompareTo((obj as WorkTimeSpan).ComperTimeSpan);
            }
        }

        //    ////排班计划
        //  //  var employee = HrManagerContext.GetInstance().Employees.Find(3);
        //{


        //public void AnalysisForPresonByMonth(int month, Employee employee)
        //    //var arrageworks = GetArrangeWorks(employee);
        //    ////这一个月的考勤 加班单 出差单 补签单 请假单
        //    var attendanceForMonth =
        //        HrManagerContext.GetInstance()
        //            .Attendances.Where(a => a.EmployeeNo == employee.EmployeeNO ).ToList().FindAll(a => a.RecordTimeToDateTime.Month == month).ToList();


        //    var overWorkForMonth =
        //        HrManagerContext.GetInstance()
        //            .OverWorks.Where(o => o.EmployeeId == employee.EmployeeId)
        //            .ToList().FindAll(a => a.BeginDateTimeToDateTime.Month == month).ToList();

        //    var businessTripsForMonth =
        //        HrManagerContext.GetInstance()
        //            .BusinessTrips.Where(b => b.EmployeeId == employee.EmployeeId).ToList()
        //            .FindAll(a => a.BeginDateToDateTime.Month == month).ToList(); 

        //    var reSignInForMonth =
        //        HrManagerContext.GetInstance()
        //            .ReSignIns.Where(r => r.EmployeeId == employee.EmployeeId).ToList().FindAll(a => a.ReSignInDateToDateTime.Month == month).ToList();

        //    var askLeaveForMonth =
        //        HrManagerContext.GetInstance()
        //            .AskLeaves.Where(a => a.EmployeeId == employee.EmployeeId).ToList().FindAll(a => a.BeginDateToDateTime.Month == month).ToList(); 

        //    var daycount = DateTime.DaysInMonth(attendanceForMonth[0].RecordTimeToDateTime.Year, month);

        //    //从这个月的第一天到最后一天
        //    for (int day = 1; day <= daycount; day++)
        //    {
        //        AnalysisForPresonByDay(arrageworks, attendanceForMonth, overWorkForMonth, businessTripsForMonth,
        //            reSignInForMonth, askLeaveForMonth, day);
        //    }


        //}
    }
}