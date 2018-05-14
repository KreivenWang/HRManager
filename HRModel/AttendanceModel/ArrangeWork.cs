using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{

    public enum ArrangeWorkTimeSpanType
    {
        [Localize("早班")]
        Moning,
        [Localize("中班")]
        Afternoon,
        [Localize("晚班")]
        Night
    }

    /// <summary>
    /// 排班
    /// </summary>
    public class ArrangeWork : ObservableObject, IViewNeededModel
    {
        /// <summary>
        /// 是否为定义的通用班次
        /// </summary>
        [NotMapped]
        public bool IsCommonDefine
        {
            get
            {
                return Department == null && Employee == null && OperatingPost == null;
            }
        }

        public int ArrangeWorkId { get; set; }

        /// <summary>
        /// 排班编号
        /// </summary>
        [StringLength(10)]
        public string ArrangeWorkNo { get; set; }
        public int ArrangeWorkNoForSort { get { return int.Parse(ArrangeWorkNo); } }

        #region WorkName 排班名字
        private string _backfield_WorkName;
        [StringLength(50)]
        public string WorkName
        {
            get { return _backfield_WorkName; }
            set
            {
                _backfield_WorkName = value;
                RaisePropertyChanged(() => WorkName);
            }
        }
        #endregion

        #region WorkGroup 排班分组
        private string _backfield_WorkGroup;
        [StringLength(50)]
        public string WorkGroup
        {
            get { return _backfield_WorkGroup; }
            set
            {
                _backfield_WorkGroup = value;
                RaisePropertyChanged(() => WorkGroup);
            }
        }
        #endregion


        public ArrangeWorkTimeSpanType SpanType { get; set; }
        /// <summary>
        /// 上班正点
        /// </summary>
        [StringLength(50)]
        public string OnDutyTime { get; set; }


        [NotMapped]
        public DateTime OnDutyTimeToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(OnDutyTime, out dateTime);
                return new DateTime(2016,7,16,dateTime.Hour,dateTime.Minute,dateTime.Second);
            }
        }



        /// <summary>
        /// 下班正点
        /// </summary>
        [StringLength(50)]
        public string OffDutyTime { get; set; }

        [NotMapped]
        public DateTime OffDutyTimeToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(OffDutyTime, out dateTime);
                var fixdatetime = new DateTime(2016, 7, 16, dateTime.Hour, dateTime.Minute, dateTime.Second);
                if (fixdatetime < OnDutyTimeToDateTime)
                    return fixdatetime.AddDays(1);
                else
                    return fixdatetime;
            }
        }

        [NotMapped]
        public bool IsPassDayWork
        {
            get
            {
                return DateTime.Parse(OnDutyTime) > DateTime.Parse(OffDutyTime);
            }
        }


        /// <summary>
        /// 班次总长
        /// </summary>
        [NotMapped]
        public TimeSpan WorkTime
        {
            get
            {
                return OffDutyTimeToDateTime.Subtract(OnDutyTimeToDateTime);
            }
        }


        /// <summary>
        /// 允许加班
        /// </summary>
        public bool AllowOverWork { get; set; }

        /// <summary>
        /// 加班开始时间
        /// </summary>
        public string OverWorkBeginTime { get; set; }

        /// <summary>
        /// 默认班次
        /// </summary>
        public bool DefaultArrange { get; set; }


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

        [NotMapped]
        public int Id
        {
            get { return ArrangeWorkId; }
        }

        public ArrangeWork Clone()
        {
            var obj = (ArrangeWork)this.MemberwiseClone();
            obj.ArrangeWorkId = 0;
            return obj;
        }
    }
}
