using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{

    public class OperatingPost : ObservableObject, IViewNeededModel
    {
        public int OperatingPostId { get; set; }

        /// <summary>
        /// 岗位编号
        /// </summary>
        [StringLength(50)]
        public string OperatingPostNo { get; set; }

        #region OperatingPostName 岗位名称
        private string _backfield_OperatingPostName;
        [StringLength(50)]
        public string OperatingPostName
        {
            get { return _backfield_OperatingPostName; }
            set
            {
                _backfield_OperatingPostName = value;
                RaisePropertyChanged(() => OperatingPostName);
            }
        }
        #endregion


        /// <summary>
        /// 属于该岗位的员工
        /// </summary>
        public virtual List<Employee> Employees { get; set; }

        /// <summary>
        /// 岗位所属部门
        /// </summary>
        //public virtual  Department Department { get; set; }
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
        public int Id { get { return OperatingPostId; } }
    }
}
