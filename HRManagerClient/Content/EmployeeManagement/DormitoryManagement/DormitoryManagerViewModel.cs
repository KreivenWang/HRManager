using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerClient.Utility;
using HRModel;
using System.Collections;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace HRManagerClient
{
    class DormitoryManagerViewModel : DBOperateViewModel<Dormitory>
    {
        public IEnumerable FiltedItems
        {
            get
            {
                if (ShowAvailableOnly) {
                    return Model.Where(d => d.IsAvailable);
                } else {
                    return Model;
                }
            }
        }

        #region ShowAvailableOnly 属性
        private bool _backfield_ShowAvailableOnly;
        public bool ShowAvailableOnly
        {
            get { return _backfield_ShowAvailableOnly; }
            set
            {
                _backfield_ShowAvailableOnly = value;
                RaisePropertyChanged(() => ShowAvailableOnly);
                RaisePropertyChanged(() => FiltedItems);
            }
        }
        #endregion

        public ICommand EmployeeSelectCommand { get; set; }
        public ICommand ClearEmployeeCommand { get; set; }

        public DormitoryManagerViewModel(EntityCollection<Dormitory> model)
            : base(model)
        {
            EmployeeSelectCommand = new RelayCommand<Dormitory>(ShowEmployeeSelectDialog);
            ClearEmployeeCommand = new RelayCommand<Dormitory>(ClearEmployeeSelectDialog);
        }

        private void ClearEmployeeSelectDialog(Dormitory selectedRow)
        {
            selectedRow.Employee = null;
        }

        private void ShowEmployeeSelectDialog(Dormitory selectedRow)
        {
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog())
                selectedRow.Employee = dlg.SelectedEp;
        }

        protected override Dormitory GetNewItemInstance()
        {
            return new Dormitory();
        }
    }
}
