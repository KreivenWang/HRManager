using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using HRModel;
using MahApps.Metro.Controls;

namespace HRManagerClient
{
    public abstract class CreateDocumentBillDialog : MetroWindow, INotifyPropertyChanged
    {
        public ObservableCollection<Employee> SelectedEmployees { get; set; }
        public Employee SelectedEp { get; set; }
        public ICommand AddEmployeeCommand { get; set; }
        public ICommand RemoveEmployeeCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public IDocumentBill ModelExample { get; private set; }
        private bool _isSubmit;

        protected CreateDocumentBillDialog(IDocumentBill newModelExample)
        {
            SelectedEmployees = new ObservableCollection<Employee>();
            AddEmployeeCommand = new RelayCommand(AddEmployee);
            RemoveEmployeeCommand = new RelayCommand(RemoveEmployee, () => SelectedEp != null);
            SubmitCommand = new RelayCommand(Submit, CanSubmit);
            _isSubmit = false;
            ShowInTaskbar = false;
            ModelExample = newModelExample;
            ModelExample.Creator = ModelSource.CurrentUser.UserName;
            DataContext = this;
        }

        private void RemoveEmployee()
        {
            SelectedEmployees.Remove(SelectedEp);
        }

        private void AddEmployee()
        {
            EmployeeSelectDialog dlg = new EmployeeSelectDialog(true);
            dlg.AddTriggered += ep => {
                if (!SelectedEmployees.Contains(ep))
                    SelectedEmployees.Add(ep);
            };
            dlg.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (!_isSubmit)
                ModelExample = null;
        }

        protected virtual bool CanSubmit()
        {
            return ModelExample != null && SelectedEmployees.Count > 0;
        }

        protected virtual void Submit()
        {
            _isSubmit = true;
            Close();
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return ModelExample != null;
        }


        #region INotifyPropertyChanged 成员

        [field: NonSerialized()]//非序列化字段
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
		
    }
}
