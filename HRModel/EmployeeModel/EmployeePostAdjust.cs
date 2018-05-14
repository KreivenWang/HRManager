using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class EmployeePostAdjust : ObservableObject, IViewNeededModel
    {
        [NotMapped]
        public int Id { get { return EmployeePostAdjustId; }}

        public int EmployeePostAdjustId { get; set; }

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

        public int? EmployeeId;
        #endregion

        #region PrevOperatingPost 原岗位
        private OperatingPost _backfield_PrevOperatingPost;
        public OperatingPost PrevOperatingPost
        {
            get { return _backfield_PrevOperatingPost; }
            set
            {
                _backfield_PrevOperatingPost = value;
                RaisePropertyChanged(() => PrevOperatingPost);
            }
        }
        #endregion

        #region CurOperatingPost 现岗位
        private OperatingPost _backfield_CurOperatingPost;
        public OperatingPost CurOperatingPost
        {
            get { return _backfield_CurOperatingPost; }
            set
            {
                _backfield_CurOperatingPost = value;
                RaisePropertyChanged(() => CurOperatingPost);
            }
        }
        #endregion

        #region PrevDepartment 原部门
        private Department _backfield_PrevDepartment;
        public Department PrevDepartment
        {
            get { return _backfield_PrevDepartment; }
            set
            {
                _backfield_PrevDepartment = value;
                RaisePropertyChanged(() => PrevDepartment);
            }
        }
        #endregion

        #region CurDepartment 现部门
        private Department _backfield_CurDepartment;
        public Department CurDepartment
        {
            get { return _backfield_CurDepartment; }
            set
            {
                _backfield_CurDepartment = value;
                RaisePropertyChanged(() => CurDepartment);
            }
        }
        #endregion

        /// <summary>
        /// 调整原因
        /// </summary>
        [StringLength(100)]
        public string AdjustReason { get; set; }

        #region RankStatus 属性
        private RankStatusEnum _backfield_RankStatus;
        public RankStatusEnum RankStatus
        {
            get { return _backfield_RankStatus; }
            set
            {
                _backfield_RankStatus = value;
                RaisePropertyChanged(() => RankStatus);
            }
        }
        #endregion

        #region AdjustDateTime 调整时间
        private string _backfield_AdjustDateTime;
        [StringLength(50)]
        public string AdjustDateTime
        {
            get { return _backfield_AdjustDateTime; }
            set
            {
                _backfield_AdjustDateTime = value;
                RaisePropertyChanged(() => AdjustDateTime);
            }
        }
        #endregion

    }
}
