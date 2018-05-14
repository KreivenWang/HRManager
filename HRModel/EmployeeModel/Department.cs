using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class Department : ObservableObject, IViewNeededModel
    {
        public Department()
        { }
        private string _departno;
        private string _departdesn;
        private bool _isOnDuty;

        public int DepartmentId
        {
            get;
            set;
        }
        /// <summary>
        /// 部门编号
        /// </summary>
        [StringLength(50)]
        public string DepartNo
        {
            set { _departno = value; }
            get { return _departno; }
        }

        #region DepartName 部门名称
        private string _backfield_DepartName;
        [StringLength(50)]
        public string DepartName
        {
            get { return _backfield_DepartName; }
            set
            {
                _backfield_DepartName = value;
                RaisePropertyChanged(() => DepartName);
            }
        }
        #endregion

        /// <summary>
        /// 职能描述
        /// </summary>
        [StringLength(200)]
        public string DepartDesn
        {
            set { _departdesn = value; }
            get { return _departdesn; }
        }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsOnDuty
        {
            set { _isOnDuty = value; }
            get { return _isOnDuty; }
        }

        /// <summary>
        ///上级级部门
        /// </summary>
        public virtual Department ParentDepartment { get; set; }

        /// <summary>
        /// 部门的员工
        /// </summary>
        public virtual List<Employee> Employees { get; set; }

        /// <summary>
        /// 部门包含的岗位
        /// </summary>
        public virtual List<OperatingPost> OperatingPosts { get; set; }

        [NotMapped]
        public int Id { get { return DepartmentId; } }
    }
}
