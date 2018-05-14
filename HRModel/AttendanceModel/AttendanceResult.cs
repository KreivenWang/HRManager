using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Steelsa.Localization;

namespace HRModel
{

    public class AskLeaveTypeForAttendance
    {
        public AskLeaveType AskLeaveType { get; set; }

        public double   TimeCount  { get; set; }

    }




    public class AttendanceResult : IViewNeededModel, IEmployeeReport
    {

        public AttendanceResult()
        {
            AskLeaveTypeForAttendances = new List<AskLeaveTypeForAttendance>();
            ChiDaoTimes = new List<double>();
            ZaoTuiTimes = new List<double>();
        }

        public int Id { get { return AttendanceResultId; } }


        public int AttendanceResultId { get; set; }

        [Localize("工号")]
        [StringLength(50)]
        public string EmployeeNo { get; set; }

        [Localize("姓名")]
        [StringLength(50)]
        public string EmployeeName { get; set; }


        [Localize("原始时间")]
        [StringLength(50)]
        public string AttendanceDate { get; set; }

        [NotMapped]
        public DateTime AttendanceDateToDatetime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(AttendanceDate, out dateTime);
                return dateTime;
            }
        }
        [Localize("考勤年")]
        [NotMapped]
        public string AttendanceDateYear
        {
            get { return AttendanceDateToDatetime.Year.ToString(); }
        }

        [Localize("考勤月")]
        [NotMapped]
        public string AttendanceDateMonth
        {
            get { return AttendanceDateToDatetime.Month.ToString(); }
        }

        [Localize("考勤日")]
        [NotMapped]
        public int AttendanceDateDay
        {
            get { return AttendanceDateToDatetime.Day; }
        }

        [Localize("星期")]
        [NotMapped]
        public string AttendanceDateWeek
        {
            get { return AttendanceDateToDatetime.DayOfWeek.EnumLocalize(); }
        }

        [Localize("上午上班")]
        [StringLength(50)]
        public string OnDutyMorning { get; set; }

        [Localize("上午下班")]
        public string OffDutyMorning { get; set; }

        [Localize("下午上班")]
        [StringLength(50)]
        public string OnDutyNoon { get; set; }

        [Localize("下午下班")]
        [StringLength(50)]
        public string OffDutyNoon { get; set; }

        [Localize("晚上上班")]
        [StringLength(50)]
        public string OnDutyNight { get; set; }

        [Localize("晚上下班")]
        [StringLength(50)]
        public string OffDutyNight { get; set; }

        [StringLength(2000)]
        public string AskLeaveTypesStr
        {
            get { return Serialize(AskLeaveTypeForAttendances); }
            set { AskLeaveTypeForAttendances = Dserialize<AskLeaveTypeForAttendance>(value); }
        }

        [NotMapped]
        [Localize("带薪休假")]
        public double WithPayTimeCount
        {
            get
            {
                if (AskLeaveTypeForAttendances != null)
                    return
                        AskLeaveTypeForAttendances.Where(a => a.AskLeaveType.IsWithPay == true)
                            .ToList()
                            .Sum(a => a.TimeCount);
                else
                {
                    return 0;
                }
            }
        }


        [NotMapped]
        [Localize("非带薪休假")]
        public double NotPayTimeCount
        {
            get
            {
                if (AskLeaveTypeForAttendances != null)
                    return
                        AskLeaveTypeForAttendances.Where(a => !a.AskLeaveType.IsWithPay)
                            .ToList()
                            .Sum(a => a.TimeCount);
                else
                {
                    return 0;
                }
            }
        }

        [NotMapped]
        public List<AskLeaveTypeForAttendance> AskLeaveTypeForAttendances { get; set; }


        private string Serialize<T>(List<T> askLeave)
        {
            using (var stream = new MemoryStream())
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(T) });
                formatter.Serialize(stream, askLeave);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        private List<T> Dserialize<T>(string str)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
            using (var stream = new MemoryStream(byteArray))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<T>), new Type[] { typeof(T) });
                return (List<T>)formatter.Deserialize(stream);
            }
        }


        /// <summary>
        /// 调休长度
        /// </summary>
        [Localize("调休")]
        [StringLength(50)]
        public string TiaoXiu { get; set; }

        /// <summary>
        /// 补签次数
        /// </summary>
        [Localize("补签次数")]
        public double ReSignIn { get; set; }

        [Localize("正常加班时长")]
        public double OverWork_normal { get; set; }

        [Localize("周末加班时长")]
        public double OverWork_weekend { get; set; }
        /// <summary>
        /// 法定假期加班时长
        /// </summary>
        [Localize("法定假期加班时长")]
        public double OverWork_voc { get; set; }

        [Localize("出差时长")]
        public double BusTrip { get; set; }

        /// <summary>
        /// 旷工
        /// </summary>
        [Localize("旷工时间")]
        public double KuanGongTimes  { get; set; }

        /// <summary>
        /// 迟到时间与次数
        /// </summary>
        public string ChiDaoStr { get { return Serialize(ChiDaoTimes); } set { ChiDaoTimes = Dserialize<double>(value); } }

        [NotMapped]
        public List<double> ChiDaoTimes { get; set; }

        [Localize("迟到次数")]
        public int ChiDaoTimesCount { get { return ChiDaoTimes?.Count ?? 0; } }

        /// <summary>
        /// 早退次数与时间
        /// </summary>
        public string ZaoTuiStr { get { return Serialize(ZaoTuiTimes); } set { ZaoTuiTimes = Dserialize<double>(value); } }

        [NotMapped]
        public List<double> ZaoTuiTimes { get; set; }

        [Localize("早退次数")]
        public int ZaoTuiTimesCount { get { return ZaoTuiTimes?.Count ?? 0; } }
        [Localize("正常工作时长")]
        public double normalWorkTime { get; set; }

        [Localize("班次")]
        [StringLength(50)]
        public string BanCi { get; set; }
        /// <summary>
        /// 是否为夜班
        /// </summary>
        [Localize("是否夜班")]
        public bool IsNightDuty { get; set; }
    }
}
