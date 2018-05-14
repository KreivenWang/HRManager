using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class VacationPlan : ObservableObject, IViewNeededModel
    {
        public int Id { get { return VacationPlanId; } }

        public int VacationPlanId { get; set; }

        #region PlanName
        private string _backfield_PlanName;
        [StringLength(50)]
        public string PlanName
        {
            get { return _backfield_PlanName; }
            set
            {
                _backfield_PlanName = value;
                RaisePropertyChanged(() => PlanName);
            }
        }
        #endregion

        #region Employee 属性
        private Employee _backfield_Employee;
        public Employee Employee
        {
            get { return _backfield_Employee; }
            set
            {
                _backfield_Employee = value;
                RaisePropertyChanged(() => Employee);
            }
        }

        public int? EmployeeId { get; set; }
        #endregion

        #region OperatingPost 属性
        private OperatingPost _backfield_OperatingPost;
        public OperatingPost OperatingPost
        {
            get { return _backfield_OperatingPost; }
            set
            {
                _backfield_OperatingPost = value;
                RaisePropertyChanged(() => OperatingPost);
            }
        }

        public int? OperatingPostId { get; set; }
        #endregion

        #region Department 属性
        private Department _backfield_Department;
        public Department Department
        {
            get { return _backfield_Department; }
            set
            {
                _backfield_Department = value;
                RaisePropertyChanged(() => Department);
            }
        }

        public int? DepartmentId { get; set; }
        #endregion
        
        public string VacationDayList
        {
            get { return Serialize(VacationDays); }
            set { VacationDays = Dserialize(value); }
        }

        #region Remark 备注
        private string _backfield_Remark;
        public string Remark
        {
            get { return _backfield_Remark; }
            set
            {
                _backfield_Remark = value;
                RaisePropertyChanged(() => Remark);
            }
        }
        #endregion

        #region IsPublicPlan 为公用方案
        private bool _backfield_IsPublicPlan;
        public bool IsPublicPlan
        {
            get { return _backfield_IsPublicPlan; }
            set
            {
                _backfield_IsPublicPlan = value;
                RaisePropertyChanged(() => IsPublicPlan);
            }
        }
        #endregion

        #region Year 年份
        private int _backfield_Year;
        public int Year
        {
            get { return _backfield_Year; }
            set
            {
                _backfield_Year = value;
                RaisePropertyChanged(() => Year);
            }
        }
        #endregion

        /// <summary>
        /// 方案中包含的法定假日
        /// </summary>
        public List<DateTime> VacationDays { get; set; }

        #region IsSundaysIncluded 是否包含所有周日
        private bool _backfield_IsSundaysIncluded;
        public bool IsSundaysIncluded
        {
            get { return _backfield_IsSundaysIncluded; }
            set
            {
                _backfield_IsSundaysIncluded = value;
                RaisePropertyChanged(() => IsSundaysIncluded);
            }
        }
        #endregion

        #region IsSaturdaysIncluded 属性
        private bool _backfield_IsSaturdaysIncluded;
        public bool IsSaturdaysIncluded
        {
            get { return _backfield_IsSaturdaysIncluded; }
            set
            {
                _backfield_IsSaturdaysIncluded = value;
                RaisePropertyChanged(() => IsSaturdaysIncluded);
            }
        }
        #endregion

        /// <summary>
        /// 周日
        /// </summary>
        public List<DateTime> Sundays
        {
            get { return Year > 0 ? GetAllWeekendDays(Year, DayOfWeek.Sunday) : new List<DateTime>(); }
        }

        /// <summary>
        /// 周六
        /// </summary>
        public List<DateTime> Saturdays
        {
            get { return Year > 0 ? GetAllWeekendDays(Year, DayOfWeek.Saturday) : new List<DateTime>(); }
        }

        /// <summary>
        /// 是否为定义的通用方案
        /// </summary>
        [NotMapped]
        public bool IsCommonDefine
        {
            get
            {
                return Department == null && Employee == null && OperatingPost == null;
            }
        }

        private string Serialize(List<DateTime> dateTimes)
        {
            using (var stream = new MemoryStream())
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<DateTime>), new Type[] { typeof(DateTime) });
                formatter.Serialize(stream, dateTimes);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        private List<DateTime> Dserialize(string str)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(str);
            using (var stream = new MemoryStream(byteArray))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<DateTime>), new Type[] { typeof(DateTime) });
                return (List<DateTime>)formatter.Deserialize(stream);
            }
        }

        bool IsWorkDay(DateTime date)
        {//返回true表示属于工作日
            return (int)date.DayOfWeek > 0 && (int)date.DayOfWeek < 6;
        }


//         public void InitWeekend()
//         {
//             var startdate = new DateTime(DateTime.Now.Year, 1, 1);
//             var enddate = new DateTime(DateTime.Now.Year,12,31);
//             while (startdate < enddate)
//             {
//                 if (!IsWorkDay(startdate))
//                     WeekendDays.Add(startdate);
//                 startdate = startdate.AddDays(1);
//             }
//         }

        /// <summary>
        /// 获取某年(year)的所有周几(dow)
        /// </summary>
        public static List<DateTime> GetAllWeekendDays(int year, DayOfWeek dow)
        {
            var result = new List<DateTime>();
            for (int month = 1; month <= 12; month++) {
                var daysInMonth = DateTime.DaysInMonth(year, month);
                var curMonthDays = new List<DateTime>();
                for (int i = 1; i <= daysInMonth; i++) {
                    curMonthDays.Add(new DateTime(year, month, i));
                }
                result.AddRange(curMonthDays.Where(d => d.DayOfWeek == dow));
            }
            return result;
        }

        public VacationPlan Clone()
        {
            var obj = (VacationPlan)this.MemberwiseClone();
            obj.VacationPlanId = 0;
            return obj;
        }
    }
}
