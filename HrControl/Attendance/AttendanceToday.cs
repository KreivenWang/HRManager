using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{

    public enum DateTimeExtendtype
    {
        WorkDay,
        WeeKendDay,
        Holiday,
    }

    public class DateTimeExtend
    {
        public DateTime DateTime { get; set; }

        public DateTimeExtendtype type;

        public DateTimeExtend()
        {
            type = DateTimeExtendtype.WorkDay;
        }
    }

    public class NearByDateTimeClass : IComparable
    {
        public NearByDateTimeClass()
        {
            Datetime = DateTime.MinValue;
            attendanceArgu = AttendanceArgu.GetInstance();
            Span = 10000;
        }


        public DateTime Datetime { get; set; }
        public double Span { get; set; }

        AttendanceArgu attendanceArgu;
        public int CompareTo(object obj)
        {
            return Span.CompareTo((obj as NearByDateTimeClass).Span);
        }


        public bool IsDispalyRecord()
        {
            return Span < attendanceArgu.AbsenteeismMinuteLimit + 120;
        }

        /// <summary>
        /// 1 旷工 2 迟到 3 早退 0 正常 
        /// </summary>
        /// <param name="dutytype">1 上班 2下班</param>
        /// <returns></returns>
        public int IsValidRecord(int dutytype)
        {
            //旷工
            if (Span > attendanceArgu.AbsenteeismMinuteLimit)
                return 1;
            else
            {
                if (dutytype == 1)
                {
                    if (Span > attendanceArgu.BeLateMinuteLimit)
                        return 2;
                }
                if (dutytype == 2)
                {
                    if (Span > attendanceArgu.EarlyLeftMinuteLimit)
                        return 3;
                }
            }
            return 0;
        }
    }
    public class AttendanceToday
    {



        public Employee Employee { get; set; }

        public int Day { get; set; }
        // 当天的请假单
        public List<AskLeave> AskleavesToDay { get; set; }

        // 当天的出差单
        public List<BusinessTrip> BusinessTripsToDay { get; set; }

        // 当天的加班单
        public List<OverWork> OverWorksToday { get; set; }

        // 当天的补签单
        public List<DateTime> ReSiginToday { get; set; }

        /// <summary>
        /// 实际推导打卡记录
        /// </summary>
       public List<DateTime> VirAttendanceDateTimes { get; set; }

       public List<DateTime> AttendancesForDayDateTimes
        {
            get
            {
                var list = AttendancesForDay.ConvertAll(a => a.RecordTimeToDateTime);
                //默认升序
                list.Sort();
                return list;
            }
        }


       // 当天的正确班次
        public String ArrangeWorkNo { get; set; }


        public List<Attendance> AttendancesForDay { get; set; }

   

       public AttendanceToday()
       {
           AskleavesToDay = new List<AskLeave>();
           BusinessTripsToDay = new List<BusinessTrip>();
           OverWorksToday = new List<OverWork>();
           ReSiginToday = new List<DateTime>();
           ArrangeWorkNo = string.Empty;
   
       }

    }
}
