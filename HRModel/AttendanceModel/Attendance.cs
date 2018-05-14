using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{
    
    /// <summary>
    /// 打卡记录
    /// </summary>
    public class Attendance :  IViewNeededModel
    {

        public int AttendanceId { get; set; }

        /// <summary>
        /// 打卡时间
        /// </summary>
        [StringLength(50)]
        public string RecordTime { get; set; }



        /// <summary>
        /// 打卡时间日期格式
        /// </summary>
        [NotMapped]
        public DateTime RecordTimeToDateTime
        {
            get
            {
                return DateTime.Parse(RecordTime);
            }
        }


        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }


        [NotMapped]
        public int Id
        {
            get { return AttendanceId; }
        }
    }
}
