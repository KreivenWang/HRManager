using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HRManagerDataAccess
{
    public class MockData
    {
        public static List<ArrangeWork> GetArrangeWorks()
        {
            return null;
        }

        public static List<Attendance> GetAttendances()
        {
            return  new List<Attendance>()
            {
                new Attendance()
                {
                    RecordTime = "2016-04-01 07:55:36.000",
                },
                new Attendance()
                {
                    RecordTime = "2016-04-01 11:30:34.000",
                },
                  new Attendance()
                {
                    RecordTime = "2016-04-01 11:46:20.000",
                },
                  new Attendance()
                {
                    RecordTime = "2016-04-01 17:00:22.000",
                },
                  new Attendance()
                {
                    RecordTime = "2016-04-01 23:51:34.000",
                },
                  new Attendance()
                {
                    RecordTime = "2016-04-02 04:30:08.000",
                },
                  new Attendance()
                {
                    RecordTime = "2016-04-02 04:47:12.000",
                },
                  new Attendance()
                {
                    RecordTime = "2016-04-02 08:00:34.000",
                },
            };
        }

        public static List<OverWork> GetOverWorks()
        {
            return  new List<OverWork>()
            {
                new OverWork()
                {
                  ApplyTime  = "",
                  BeginDateTime = "2016-04-02 00:00",
                  EndDateTime = "2016-04-02 04:30",
                  //ReduceTime = "4:30",
                },
                 new OverWork()
                {
                  ApplyTime  = "",
                  BeginDateTime = "2016-04-02 05:00",
                  EndDateTime = "2016-04-02 08:00",
                  //ReduceTime = "3:00",
                },
                 new OverWork()
                {
                  ApplyTime  = "",
                  BeginDateTime = "2016-04-01 16:30",
                  EndDateTime = "2016-04-01 17:00",
                  //ReduceTime = "0:30",
                },
            };
        } 
    }
}
