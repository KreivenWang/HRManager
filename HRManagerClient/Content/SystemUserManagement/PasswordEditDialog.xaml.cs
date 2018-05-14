using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HRModel;
using MahApps.Metro.Controls;

namespace HRManagerClient
{
    /// <summary>
    /// PasswordEditDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PasswordEditDialog : MetroWindow
    {
        private readonly SystemUser _user;
        private readonly bool _isCreatingMode;

        public PasswordEditDialog(SystemUser user, bool isCreatingMode)
        {
            _user = user;
            _isCreatingMode = isCreatingMode;
            InitializeComponent();
            userNameBox.Text = _user.UserName;
            oldPwdBox.Visibility = _isCreatingMode ? Visibility.Collapsed : Visibility.Visible;
            userNameBox.IsReadOnly = !_isCreatingMode;
        }

        private void OldPwdBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void NewPwdBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void NewPwdBoxRepeat_OnPasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (_isCreatingMode)
            {
                if (string.IsNullOrWhiteSpace(userNameBox.Text))
                {
                    MessageBox.Show("用户名不能为空", "提交失败");
                }
                else if (ModelSource.SystemUsers.ToList().Exists(u => u.UserName == userNameBox.Text))
                {
                    MessageBox.Show("用户名已存在", "提交失败");
                }
                CheckPasswordAndSubmit();
            }
            else
            {
                if (ModelSource.SystemUsers.ToList()
                .Exists(u => u.Password == oldPwdBox.Password && u.UserName == _user.UserName))
                {
                    CheckPasswordAndSubmit();
                }
                else
                {
                    MessageBox.Show("密码错误", "提交失败");
                }
            }
        }

        private void CheckPasswordAndSubmit()
        {
            if (string.IsNullOrWhiteSpace(newPwdBox.Password))
            {
                MessageBox.Show("新密码不能为空", "提交失败");
            }
            else if (newPwdBox.Password != newPwdBoxRepeat.Password)
            {
                MessageBox.Show("两次密码不同", "提交失败");
            }
            else
            {
                _user.UserName = userNameBox.Text;
                _user.Password = newPwdBox.Password;
                ModelSource.SystemUsers.UpdateEntity();
                this.Close();
            }
        }
    }
}
