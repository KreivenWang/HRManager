using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class ReSignIn : ObservableObject, IViewNeededModel, IDocumentBill
    {
        #region ReSignInDate 补签日期
        private string _backfield_ReSignInDate;
        public string ReSignInDate
        {
            get { return _backfield_ReSignInDate; }
            set
            {
                _backfield_ReSignInDate = value;
                RaisePropertyChanged(() => ReSignInDate);
            }
        }
        #endregion



        [NotMapped]
        public DateTime ReSignInDateToDateTime
        {
            get
            {
                DateTime dateTime;
                DateTime.TryParse(ReSignInDate, out dateTime);
                return dateTime;
            }
        }

      
        public int Id { get { return ReSignInId; }}

        public int ReSignInId { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        [StringLength(100)]
        public string Reason { get; set; }
        public string ReSignInType { get; set; }

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

        public ReSignIn Clone()
        {
            var obj = (ReSignIn)this.MemberwiseClone();
            obj.ReSignInId = 0;
            return obj;
        }
    }
}
