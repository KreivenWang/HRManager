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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HRManagerClient
{
    /// <summary>
    /// EmployeeEditDialog.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeEditDialog : MetroWindow
    {
        public EmployeeEditDialog()
        {
            InitializeComponent();
        }

        private void OnSourceUpdated(object sender, DataTransferEventArgs e)
        {
//             var vm = DataContext as EmployeeViewModel;
//             if (vm != null) {
//                 vm.ParentVM.UpdateItem();
//             }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if((DataContext as EmployeeEditViewModel).UpdateItem())
                this.Close();
        }
    }
}
