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
    /// WkarDefSelectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class WkarDefSelectDialog : MetroWindow, INotifyPropertyChanged
    {
        public IEnumerable FiltedItems
        {
            get
            {
                IEnumerable<ArrangeWork> filtered = Wkars;
                if (!String.IsNullOrEmpty(FilterWkarName)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.WorkName)
                        && item.WorkName.Contains(FilterWkarName));
                }
                if (!String.IsNullOrEmpty(FilterWkarNo)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.ArrangeWorkNo) && item.ArrangeWorkNo.Contains(FilterWkarNo));
                }
                return filtered;
            }
        }

        #region FilterWkarNo 属性
        private string _backfield_FilterWkarNo;
        public string FilterWkarNo
        {
            get { return _backfield_FilterWkarNo; }
            set
            {
                _backfield_FilterWkarNo = value;
                OnPropertyChanged("FilterWkarNo");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region FilterWkarName 属性
        private string _backfield_FilterWkarName;
        public string FilterWkarName
        {
            get { return _backfield_FilterWkarName; }
            set
            {
                _backfield_FilterWkarName = value;
                OnPropertyChanged("FilterWkarName");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region SelectedWkar 属性
        private ArrangeWork _backfield_SelectedWkar;
        public ArrangeWork SelectedWkar
        {
            get { return _backfield_SelectedWkar; }
            set
            {
                _backfield_SelectedWkar = value;
                OnPropertyChanged("SelectedWkar");
            }
        }
        #endregion

        public ObservableCollection<ArrangeWork> Wkars { get; set; }

        public ICommand SelectDpCommand { get; set; }
        public ICommand ClearDpCommand { get; set; }
        public ICommand SelectEpCommand { get; set; }
        public ICommand ClearEpCommand { get; set; }
        public ICommand SelectOppCommand { get; set; }
        public ICommand ClearOppCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public WkarDefSelectDialog()
        {
            InitializeComponent();
            Wkars = new ObservableCollection<ArrangeWork>(ModelSource.DefinedArrangeWorks);
            SelectDpCommand = new RelayCommand(ShowDpSelectDialog, CanSelectCondition);
            ClearDpCommand = new RelayCommand(ClearSelectedDp, CanSelectCondition);
            SelectEpCommand = new RelayCommand(ShowEpSelectDialog, CanSelectCondition);
            ClearEpCommand = new RelayCommand(ClearSelectedEp, CanSelectCondition);
            SelectOppCommand = new RelayCommand(ShowOppSelectDialog, CanSelectCondition);
            ClearOppCommand = new RelayCommand(ClearSelectedOpp, CanSelectCondition);
            SubmitCommand = new RelayCommand(Submit, CanSubmit);
            this.DataContext = this;
        }

        private bool CanSelectCondition()
        {
            return SelectedWkar != null;
        }

        private bool CanSubmit()
        {
            return SelectedWkar != null && (SelectedWkar.OperatingPost != null || SelectedWkar.Department != null || SelectedWkar.Employee != null);
        }

        private void Submit()
        {
            if (SelectedWkar != null)
                this.Close();
        }

        private void ClearSelectedOpp()
        {
            SelectedWkar.OperatingPost = null;
        }

        private void ShowOppSelectDialog()
        {
            if (SelectedWkar == null) return;
            PostSelectDialog dlg = new PostSelectDialog();
            if (SelectedWkar.Department != null) {
                dlg.IsDpFilterEditable = false;
                dlg.DpFilter = SelectedWkar.Department;
            }
            if (dlg.ShowDialog()) {
                SelectedWkar.OperatingPost = dlg.SelectedOpp;
            }
        }

        private void ClearSelectedEp()
        {
            SelectedWkar.Employee = null;
        }

        private void ShowEpSelectDialog()
        {
            if (SelectedWkar == null) return;
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog())
                SelectedWkar.Employee = dlg.SelectedEp;
        }

        private void ClearSelectedDp()
        {
            SelectedWkar.Department = null;
            SelectedWkar.OperatingPost = null;
        }

        private void ShowDpSelectDialog()
        {
            if (SelectedWkar == null) return;
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog())
                SelectedWkar.Department = dlg.SelectedDpvm.Model;
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return SelectedWkar != null;
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
