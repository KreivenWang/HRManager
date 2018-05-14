using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HRManagerClient
{
    class SystemUserManagerViewModel : DBOperateViewModel<SystemUser>
    {
        public bool CanModify
        {
            get { return ModelSource.CurrentUser.SystemRole.Enabled_SystemUser; }
        }
        //public ICommand SelectEpCommand { get; set; }
        public IEnumerable SystemRoleItems
        {
            get { return ModelSource.SystemRoles; }
        }

        public ICommand ChangePasswordCommand { get; set; }

        public SystemUserManagerViewModel(EntityCollection<SystemUser> model)
            : base(model)
        {
            ChangePasswordCommand = new RelayCommand(ChangePassword);
        }

        private void ChangePassword()
        {
            if (SelectedItem != null)
            {
                PasswordEditDialog dlg = new PasswordEditDialog(SelectedItem,false);
                dlg.ShowDialog();
            }
        }

        protected override void CreateItemSubmit()
        {
            if (CreatingItem.UserName == null)
                MessageBox.Show("用户名未填写.");
            else if (CreatingItem.SystemRole == null)
                MessageBox.Show("系统角色类型为选择.");
            else
                base.CreateItemSubmit();
        }

        protected override bool RemoveItemCanExecute()
        {
            return base.RemoveItemCanExecute() && !SelectedItem.IsDefaultUser;
        }

        public void OnLoadingRow(DataGridRowEventArgs e)
        {
            if ((e.Row.DataContext as SystemUser).IsDefaultUser)
            {
                //e.Row.IsEnabled = false; //可修改密码
            }
        }

        protected override SystemUser GetNewItemInstance()
        {
            var newU = new SystemUser
            {
                UserName = "新用户",
                Creator = ModelSource.CurrentUser.UserName,
                CreateTime = DateTime.Now.ToString(),
                IsActive = true
            };
            PasswordEditDialog dlg = new PasswordEditDialog(newU, true);
            dlg.ShowDialog();
            var pwd = dlg.newPwdBox.Password;
            return string.IsNullOrWhiteSpace(pwd) ? null : newU;
        }
    }
}
