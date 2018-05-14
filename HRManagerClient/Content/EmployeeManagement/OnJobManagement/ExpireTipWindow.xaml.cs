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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HRManagerClient
{
    /// <summary>
    /// ExpireTipWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExpireTipWindow : MetroWindow
    {
        Storyboard stdEnd;

        public int ExpiredCount
        {
            get { return  int.Parse(ExpiredCountTB.Text); }
            set { ExpiredCountTB.Text = value.ToString(); }
        }
        public int ExpireNearCount
        {
            get { return int.Parse(ExpireNearCountTB.Text); }
            set { ExpireNearCountTB.Text = value.ToString(); }
        }
        public int LeaveCount
        {
            get { return int.Parse(LeaveCountTB.Text); }
            set { LeaveCountTB.Text = value.ToString(); }
        }

        public ExpireTipWindow()
        {
            InitializeComponent();
            Top = ModelSource.ExpectedTipTop;
            Left = ModelSource.ExpectedTipLeft;
            stdEnd = (Storyboard)this.Resources["End"];
            stdEnd.Completed += stdEnd_Completed;
        }

        void stdEnd_Completed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IKnow_Click(object sender, RoutedEventArgs e)
        {
            stdEnd.Begin();
        }
    }
}
