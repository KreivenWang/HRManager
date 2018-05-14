using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class Employee : ObservableObject, IViewNeededModel
    {
        public Employee()
        {

        }

        public int EmployeeId { get; set; }

        public virtual List<EmployeePostAdjust> EmployeePostAdjusts { get; set; }

        public virtual EmployeeBaseInfo EmployeeBaseInfo { get; set; }

        public int EmployeeBaseInfoId { get; set; }

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

        #region OperatingPost 属性
        private OperatingPost _backfield_OperatingPost;
        public virtual OperatingPost OperatingPost
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

        /// <summary>
        /// 工号
        /// </summary>
        [StringLength(50)]
        public string EmployeeNO { set; get; }

        #region HireDate 入职时间
        private string _backfield_HireDate;
        [StringLength(50)]
        public string HireDate
        {
            get { return _backfield_HireDate; }
            set
            {
                _backfield_HireDate = value;
                RaisePropertyChanged(() => HireDate);
            }
        }
        #endregion

        #region ExpireDate 合同到期时间 or 离职时间 or 自动离职时间
        private string _backfield_ExpireDate;
        [StringLength(50)]
        public string ExpireDate
        {
            get { return _backfield_ExpireDate; }
            set
            {
                _backfield_ExpireDate = value;
                RaisePropertyChanged(() => ExpireDate);
            }
        }
        #endregion

        /// <summary>
        /// 离职原因
        /// </summary>
        [StringLength(200)]
        public string ExpireReason { get; set; }

        /// <summary>
        /// 人员状态
        /// </summary>
        public JobStatusEnum State { set; get; }


        [NotMapped]
        public int Id
        {
            get { return EmployeeId; }
        }
    }
}
