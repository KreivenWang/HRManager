using MahApps.Metro.Controls;
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

namespace HRManagerClient
{
    /// <summary>
    /// PostTransferAddDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PostTransferAddDialog : MetroWindow
    {
        public PostTransferAddDialog()
        {
            InitializeComponent();
        }
        bool isInfoComplete = false;
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            isInfoComplete = (DataContext as PostTransferAddViewModel).GetCompleteInfo();
            if (!isInfoComplete) {
                MessageBox.Show("信息填写不完整");
            } else {
                this.Close();
            }

        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return isInfoComplete;
        }
    }
}
