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
    /// VacationPlanSelectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class VacationPlanSelectDialog : MetroWindow, INotifyPropertyChanged
    {

        #region SelectedPlan 属性
        private VacationPlan _backfieldSelectedPlan;
        public VacationPlan SelectedPlan
        {
            get { return _backfieldSelectedPlan; }
            set
            {
                _backfieldSelectedPlan = value;
                OnPropertyChanged("SelectedPlan");
            }
        }
        #endregion

        public ObservableCollection<VacationPlan> Plans { get; set; }

        public ICommand SelectDpCommand { get; set; }
        public ICommand ClearDpCommand { get; set; }
        public ICommand SelectEpCommand { get; set; }
        public ICommand ClearEpCommand { get; set; }
        public ICommand SelectOppCommand { get; set; }
        public ICommand ClearOppCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public VacationPlanSelectDialog()
        {
            InitializeComponent();
            Plans = new ObservableCollection<VacationPlan>(ModelSource.DefVacationPlans);
            SelectDpCommand = new RelayCommand(ShowDpSelectDialog, CanSelectCondition);
            ClearDpCommand = new RelayCommand(ClearSelectedDp);
            SelectEpCommand = new RelayCommand(ShowEpSelectDialog, CanSelectCondition);
            ClearEpCommand = new RelayCommand(ClearSelectedEp);
            SelectOppCommand = new RelayCommand(ShowOppSelectDialog, CanSelectCondition);
            ClearOppCommand = new RelayCommand(ClearSelectedOpp);
            SubmitCommand = new RelayCommand(Submit, CanSubmit);
            this.DataContext = this;
        }

        private bool CanSelectCondition()
        {
            return SelectedPlan != null;
        }

        private bool CanSubmit()
        {
            return SelectedPlan != null && (SelectedPlan.OperatingPost != null || SelectedPlan.Department != null || SelectedPlan.Employee != null);
        }

        private void Submit()
        {
            if (SelectedPlan != null)
                this.Close();
        }

        private void ClearSelectedOpp()
        {
            SelectedPlan.OperatingPost = null;
        }

        private void ShowOppSelectDialog()
        {
            if (SelectedPlan == null) return;
            PostSelectDialog dlg = new PostSelectDialog();
            if (SelectedPlan.Department != null) {
                dlg.IsDpFilterEditable = false;
                dlg.DpFilter = SelectedPlan.Department;
            }
            if (dlg.ShowDialog()) {
                SelectedPlan.OperatingPost = dlg.SelectedOpp;
            }
        }

        private void ClearSelectedEp()
        {
            SelectedPlan.Employee = null;
        }

        private void ShowEpSelectDialog()
        {
            if (SelectedPlan == null) return;
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog())
                SelectedPlan.Employee = dlg.SelectedEp;
        }

        private void ClearSelectedDp()
        {
            SelectedPlan.Department = null;
            SelectedPlan.OperatingPost = null;
        }

        private void ShowDpSelectDialog()
        {
            if (SelectedPlan == null) return;
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog())
                SelectedPlan.Department = dlg.SelectedDpvm.Model;
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return SelectedPlan != null;
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
