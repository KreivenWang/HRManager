using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel 
{



    public class TiaoXiu : ObservableObject, IViewNeededModel, IDocumentBill
    {
        /// <summary>
        /// 调节日,本来是工作日
        /// </summary>
        [NotMapped]
        public DateTime CurDateTime
        {
            get { return DateTime.Parse(CurStartDateTimeStr); }
        }

        /// <summary>
        /// 被调日,本来是节假日
        /// </summary>
        [NotMapped]
        public DateTime TiaoXiuDateTime
        {
            get { return DateTime.Parse(TiaoXiuStartDateTimeStr); }
        }

        public int Id { get { return TiaoXiuId; }}


        public int TiaoXiuId { get; set; }


        /// <summary>
        /// 调休单
        /// </summary>
        public string TiaoXiuNo { get; set; }
        /// <summary>
        /// 调节日,本来是工作日
        /// </summary>
        public string CurStartDateTimeStr { get; set; }

        public string CurEndDateTimeStr { get; set; }

        /// <summary>
        /// 被调日,本来是节假日
        /// </summary>
        public string TiaoXiuStartDateTimeStr { get; set; }

        public string TiaoXiuEndDateTimeStr { get; set; }


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
        #endregion
        public int? EmployeeId { get; set; }

        public string Reason { get; set; }
        public string Creator { get; set; }

        /// <summary>
        /// 是否是半天
        /// </summary>
        public bool IsHalfDay  { get; set; }

        public TiaoXiu Clone()
        {
            var obj = (TiaoXiu)this.MemberwiseClone();
            obj.TiaoXiuId = 0;
            return obj;
        }


    }

}
