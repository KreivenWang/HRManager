using HRModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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

namespace HRManagerClient
{
    /// <summary>
    /// SystemRoleManagerUI.xaml 的交互逻辑
    /// </summary>
    public partial class SystemRoleManagerUI : Control
    {
        public SystemRoleManagerUI()
        {
            InitializeComponent();
        }

        private void DataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            (DataContext as SystemRoleManagerViewModel).OnAutoGeneratingColumn(e);
        }

        private void DataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            (DataContext as SystemRoleManagerViewModel).OnLoadingRow(e);
        }
    }
}
