using GalaSoft.MvvmLight.Command;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// DepartmentSelectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentSelectDialog : MetroWindow
    {
        public DepartmentViewModel SelectedDpvm { get; private set; }
        public ObservableCollection<DepartmentViewModel> Dpvms { get; set; }
        public ICommand SelectCommand { get; set; }
        public DepartmentSelectDialog()
        {
            InitializeComponent();
            SelectCommand = new RelayCommand<DepartmentViewModel>(SelectExecute);
            Dpvms = new ObservableCollection<DepartmentViewModel>();
            Dpvms.BuildDpVM_TreeStructs(ModelSource.Departments);
            this.DataContext = this;
            Console.WriteLine(@"DepartmentSelectDialog constructed.");
        }

        private void SelectExecute(DepartmentViewModel obj)
        {
            SelectedDpvm = obj;
            this.Close();
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return SelectedDpvm != null;
        }
    }
}
