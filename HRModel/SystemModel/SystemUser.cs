using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class SystemUser : ObservableObject, IViewNeededModel
    {
        public static readonly SystemUser DefaultAdmin = new SystemUser()
        {
            UserName = "Admin",
            Password = "Admin",
            SystemRole = SystemRole.Default,
            IsActive = true,
            CreateTime = DateTime.Now.ToString(),
            IsDefaultUser = true
        };

        public int SystemUserId { get; set; }

        #region UserName 属性
        private string _backfield_UserName;
        [StringLength(50)]
        public string UserName
        {
            get { return _backfield_UserName; }
            set
            {
                _backfield_UserName = value;
                RaisePropertyChanged(() => UserName);
            }
        }
        #endregion

        /// <summary>
        /// 登陆密码
        /// </summary>
        [StringLength(50)]
        public string Password { get; set; }

        #region SystemRole 所属系统角色
        private SystemRole _backfield_SystemRole;
        public SystemRole SystemRole
        {
            get { return _backfield_SystemRole; }
            set
            {
                _backfield_SystemRole = value;
                RaisePropertyChanged(() => SystemRole);
            }
        }
        #endregion

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 启用状态
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }

        public bool IsDefaultUser { get; private set; }

        public int Id
        {
            get { return SystemUserId; }
        }
    }
}
