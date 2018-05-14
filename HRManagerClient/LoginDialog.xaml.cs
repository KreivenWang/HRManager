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
using GalaSoft.MvvmLight.Command;
using HRModel;
using MahApps.Metro.Controls;

namespace HRManagerClient
{
    /// <summary>
    /// LoginDialog.xaml 的交互逻辑
    /// </summary>
    public partial class LoginDialog : MetroWindow
    {
        public SystemUser User { get; set; }
        private bool _logedIn;

        public ICommand LoginCommand { get; set; }
        public LoginDialog()
        {
            InitializeComponent();
            this.DataContext = this;
            LoginCommand = new RelayCommand(LoginExecute, CanLogin);
            User = new SystemUser {UserName = "Admin"};
            Loaded += LoginDialog_Loaded;
        }

        void LoginDialog_Loaded(object sender, RoutedEventArgs e)
        {
            userNameBox.SelectionStart = userNameBox.Text.Length;
            userNameBox.Focus();
        }

        public void LoginExecute()
        {
            var foundUser =
                ModelSource.SystemUsers.ToList()
                    .Find(user => user.UserName == User.UserName && user.Password == User.Password);
            if (foundUser != null)
            {
                _logedIn = true;
                User = foundUser;
            }
            if (_logedIn)
                Close();
            else MessageBox.Show("用户名或密码错误", "登录失败");
        }

        public bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(User.UserName) && !string.IsNullOrWhiteSpace(User.Password);
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return _logedIn;
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            User.Password = (sender as PasswordBox).Password;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if(!_logedIn)
                Application.Current.Shutdown();
        }
    }
}
