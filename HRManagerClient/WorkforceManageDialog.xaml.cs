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
    /// WorkforceManageDialog.xaml 的交互逻辑
    /// </summary>
    public partial class WorkforceManageDialog : MetroWindow
    {
        public WorkforceManageDialog()
        {
            InitializeComponent();
            List<TestData> d = new List<TestData>();
            d.Add(new TestData { Id = 0, Time = new DateTime(2016, 6, 25, 22, 11, 55), CanOverWork = true });
            d.Add(new TestData { Id = 1, Time = new DateTime(2016, 6, 25, 22, 22, 55),CanOverWork = false });
            for (int i = 0; i < 100; i++) {
                d.Add(new TestData { Id = 1, Time = new DateTime(2016, 6, 25, 12, 34, 55), CanOverWork = true });
            }
            this.DataContext = d;
        }
        class TestData
        {
            public int Id { get; set; }
            public DateTime Time { get; set; }
            public bool CanOverWork { get; set; }
        }
    }
}
