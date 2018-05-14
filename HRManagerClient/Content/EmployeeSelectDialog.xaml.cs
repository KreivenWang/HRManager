using GalaSoft.MvvmLight.Command;
using HRModel;
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// EmployeeSelectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeSelectDialog : MetroWindow, INotifyPropertyChanged
    {
        private bool _isSelectClose;
        private bool _keepOpen;
        public event Action<Employee> AddTriggered;
        public IEnumerable FiltedItems
        {
            get
            {
                IEnumerable<Employee> filtered = Epvms;
                if (!String.IsNullOrEmpty(NameFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.EmployeeBaseInfo.EmployName)
                        && item.EmployeeBaseInfo.EmployName.Contains(NameFilterText));
                }
                if (!String.IsNullOrEmpty(WorkNumFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.EmployeeNO) && item.EmployeeNO.Contains(WorkNumFilterText));
                }
                if (SexFilter != SexEnum.Unknown) {
                    filtered = filtered.Where(item => item.EmployeeBaseInfo.Sex == SexFilter);
                }
                if (DpFilter != null)
                {
                    filtered = filtered.Where(item => item.Department == DpFilter);
                }
                return filtered;
            }
        }

        #region SexFilter 属性
        private SexEnum _backfield_SexFilter;

        public SexEnum SexFilter
        {
            get { return _backfield_SexFilter; }
            set
            {
                _backfield_SexFilter = value;
                OnPropertyChanged("SexFilter");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region NameFilterText 属性



        private string _backfield_NameFilterText;

        public string NameFilterText
        {
            get { return _backfield_NameFilterText; }
            set
            {
                _backfield_NameFilterText = value;
                OnPropertyChanged("NameFilterText");
                OnPropertyChanged("FiltedItems");
            }
        }

        #endregion

        #region WorkNumFilterText 属性

        private string _backfield_WorkNumFilterText;

        public string WorkNumFilterText
        {
            get { return _backfield_WorkNumFilterText; }
            set
            {
                _backfield_WorkNumFilterText = value;
                OnPropertyChanged("WorkNumFilterText");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region DpFilter 属性
        private Department _backfield_DpFilter;
        public Department DpFilter
        {
            get { return _backfield_DpFilter; }
            set
            {
                _backfield_DpFilter = value;
                OnPropertyChanged("DpFilter");
            }
        }
        #endregion

        public Employee SelectedEp { get; set; }
        public ObservableCollection<Employee> Epvms { get; set; }
        public EmployeeSelectDialog(bool keepOpen = false)
        {
            _keepOpen = keepOpen;
            InitializeComponent();
            Epvms = new ObservableCollection<Employee>(ModelSource.Employees.ToList());
            SexFilter = SexEnum.Unknown;
            this.DataContext = this;
        }
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedEp != null)
            {
                _isSelectClose = true;
                if (_keepOpen)
                    AddTriggered?.Invoke(SelectedEp);
                else
                    Close();
            }
        }

        private void SelectDp_Click(object sender, RoutedEventArgs e)
        {
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog())
            {
                DpFilter = dlg.SelectedDpvm.Model;
            }
        }

        private void ClearSelectedDp_Click(object sender, RoutedEventArgs e)
        {
            DpFilter = null;
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return _isSelectClose;
        }

        #region INotifyPropertyChanged 成员

        [field: NonSerializedAttribute()]//非序列化字段
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        
    }
}
