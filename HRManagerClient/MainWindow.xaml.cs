using HRManagerClient.Utility;
using HRManagerDataAccess;
using HRModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro.Controls.Dialogs;

namespace HRManagerClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel.MainWindowHandler = this;
            MainViewModel vm = new MainViewModel();
            DataContext = vm;
            this.LayoutUpdated += MainWindow_LayoutUpdated;
        }

        void MainWindow_LayoutUpdated(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            timeTextBlock.Text = string.Format("{0} {1}", now.ToLongDateString(), now.ToLongTimeString());
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        public async Task<ProgressDialogController> ShowProgressDialog()
        {
            return await this.ShowProgressAsync("Please wait...", "Progress message");
        }
    }
}
