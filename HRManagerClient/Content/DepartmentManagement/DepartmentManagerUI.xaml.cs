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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HRManagerClient
{
    /// <summary>
    /// DepartmentManagerUI.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentManagerUI : Control
    {
        public DepartmentManagerUI()
        {
            InitializeComponent();
        }

        private void TreeViewItem_Drop(object sender, DragEventArgs e)
        {
            (DataContext as DepartmentManagerViewModel).DropCommand.Execute(e);
        }
    }
}
