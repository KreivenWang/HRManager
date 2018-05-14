using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class AskLeave : ObservableObject, IViewNeededModel, IDocumentBill
    {
        [NotMapped]
        public int Id
        {
            get { return AskLeaveId; }
        }

        public int AskLeaveId { get; set; }


        /// <summary>
        /// 编号
        /// </summary>
        public string AskForLeaveNo { get; set; }

        /// <summary>
        /// 生成
        /// </summary>
        public string AskForLeaveTitle { get; set; }

        /// <summary>
        /// 请假类型
        /// </summary>
        public AskLeaveType AskLeaveType { get; set; }

        public int? AskLeaveTypeId { get; set; }

        [StringLength(50)]
        public String BeginDate { get; set; }



        [NotMapped]
        public DateTime BeginDateToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(BeginDate, out dateTime);
                return dateTime;
            }
        }


        [StringLength(50)]
        public String EndDate { get; set; }


        [NotMapped]
        public DateTime EndDateToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(EndDate, out dateTime);
                return dateTime;
            }
        }

        [StringLength(100)]
        public string Reason { get; set; }


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

        /// <summary>
        /// 制单人
        /// </summary>
        [StringLength(50)]
        public string Creator { get; set; }


        /// <summary>
        /// 是否算工时
        /// </summary>
        public string IsOnDuty { get; set; }

        public AskLeave Clone()
        {
            var obj = (AskLeave) this.MemberwiseClone();
            obj.AskLeaveId = 0;
            return obj;
        }
    }
}
