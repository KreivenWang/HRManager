using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HRManagerClient
{
    class OnJobManagerViewModel : DBOperateViewModel<Employee>
    {
        public ICommand ShowEmployeeDetailCommand { get; set; }
        public ICommand ExpireRemindCommand { get; set; }

        public OnJobManagerViewModel(EntityCollection<Employee> model)
            : base(model)
        {
            ShowEmployeeDetailCommand = new RelayCommand(ShowEmployeeDetail);
            ExpireRemindCommand = new RelayCommand<DataGridRowEventArgs>(ShowExpireRemind);
            RegistReceiverSlot(EmployeeEditViewModel.DetailChangedToken, SaveChanges);
        }

        internal void ShowExpireRemind(DataGridRowEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("LoadingRow");
            Employee ep = e.Row.DataContext as Employee;
            var days = DateTime.Now.GetDateSpanDays(ep.ExpireDate);
            if (days < ModelSource.ExpireRemindDaySpan) {
                e.Row.Background = Brushes.Khaki;
                e.Row.Foreground = Brushes.Brown;
            }
        }
         
        private void ShowEmployeeDetail()
        {
            if (SelectedItem == null) return;
            EmployeeEditViewModel.ShowDetailDialog(SelectedItem, false);
        }
    }
}
