using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class OverWork : ObservableObject, IAttendance, IViewNeededModel, IDocumentBill
    {
        public int OverWorkId { get; set; }

        /// <summary>
        /// 加班开始时间
        /// </summary>
        [StringLength(50)]
        public string BeginDateTime { get; set; }

        [NotMapped]
        public DateTime BeginDateTimeToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(BeginDateTime, out dateTime);
                return dateTime;
            }
        }

        /// <summary>
        /// 加班结束时间
        /// </summary>
        [StringLength(50)]
        public string EndDateTime { get; set; }


        [NotMapped]
        public DateTime EndDateTimeToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(EndDateTime, out dateTime);
                return dateTime;
            }
        }

        /// <summary>
        /// 加班类型
        /// </summary>
        [StringLength(50)]
        public string OverWorkType { get; set; }

//        /// <summary>
//        /// 减时
//        /// </summary>
//        [StringLength(50)]
//        public string ReduceTime { get; set; }


        #region ApplyTime 申请时间
        private string _backfield_ApplyTime;
        [StringLength(50)]
        public string ApplyTime
        {
            get { return _backfield_ApplyTime; }
            set
            {
                _backfield_ApplyTime = value;
                RaisePropertyChanged(() => ApplyTime);
            }
        }
        #endregion

        /// <summary>
        /// 上班直落校验
        /// </summary>
        public bool IsOnDuty { get; set; }

        /// <summary>
        /// 下班直落校验
        /// </summary>
        public bool IsOffDuty { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        [StringLength(50)]
        public string Creator { get; set; }

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

        public OverWork Clone()
        {
            var obj = (OverWork)this.MemberwiseClone();
            obj.OverWorkId = 0;
            return obj;
        }

        public int Id { get { return OverWorkId; } }
    }
}
