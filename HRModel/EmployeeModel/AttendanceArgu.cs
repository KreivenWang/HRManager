using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class AttendanceArgu
    {
        private static AttendanceArgu Default;
        public static readonly string FileName = "DefaultAttendanceArgu.data";

        /// <summary>
        /// 迟到时间限制 分钟
        /// </summary>
        public int BeLateMinuteLimit { get; set; }


        /// <summary>
        /// 旷工时间限制  分钟
        /// </summary>
        public int AbsenteeismMinuteLimit { get; set; }

        /// <summary>
        /// 早退时间限制 分钟
        /// </summary>
        public int EarlyLeftMinuteLimit { get; set; }


        public static AttendanceArgu GetInstance()
        {
            if (Default == null)
            {
                try
                {
                    Default = SerializeHelper.DeSerialize<AttendanceArgu>(FileName);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    Default = new AttendanceArgu();
                }
            }
            return Default;
        }

    }
}
