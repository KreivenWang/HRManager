using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HRModel;

namespace HRManagerClient
{
    public class DpSelectVM : ViewModelBase
    {
        public event Action<Department> SelectFinished;
        public DepartmentViewModel SelectedDpvm { get; private set; }
        public ObservableCollection<DepartmentViewModel> Dpvms { get; set; }
        public ICommand SelectCommand { get; set; }

        public DpSelectVM()
        {
            SelectCommand = new RelayCommand<DepartmentViewModel>(SelectExecute);
            Dpvms = new ObservableCollection<DepartmentViewModel>();
            Dpvms.BuildDpVM_TreeStructs(ModelSource.Departments);
        }

        private void SelectExecute(DepartmentViewModel obj)
        {
            SelectedDpvm = obj;
            SelectFinished?.Invoke(SelectedDpvm.Model);
        }
    }
}
