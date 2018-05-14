using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using HrControl;
using Steelsa.Localization;

namespace HRManagerClient
{
    class BaseSalaryManagerViewModel : ViewModelBase<BaseSalaryControl>
    {
        public BaseSalary Arg
        {
            get { return Model.GetAttendanceArgu(); }
        }

        public ICommand SaveCommand { get; set; }
        public BaseSalaryManagerViewModel(BaseSalaryControl control)
            : base(control)
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            Model.UpdateAttendanceArgu(Arg);
        }
    }
}
