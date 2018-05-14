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
using Steelsa;

namespace HRManagerClient
{
    class OperatingPostManagerViewModel : DBOperateViewModel<OperatingPost>
    {
        public ICommand DpSelectCommand { get; set; }
        public ICommand ClearSelectedDpCommand { get; set; }
        public OperatingPostManagerViewModel(EntityCollection<OperatingPost> model)
            : base(model)
        {
            DpSelectCommand = new RelayCommand<OperatingPost>(ShowDpSelectDialog);
            ClearSelectedDpCommand = new RelayCommand<OperatingPost>(ClearDpSelectDialog);
        }

        public void ClearDpSelectDialog(OperatingPost selectedRow)
        {
            selectedRow.Department = null;
        }

        public void ShowDpSelectDialog(OperatingPost selectedRow)
        {
            //Console.WriteLine(@"ShowDpSelectDialog Clicked!");
            //var selectDpVm = StatusConsole.ShowFlyout() as DpSelectVM;
            //Console.WriteLine("Flyout SHown");
            //if (selectDpVm != null)
            //    selectDpVm.SelectFinished += dp =>
            //    {
            //        selectedRow.Department = selectDpVm.SelectedDpvm.Model;
            //Console.WriteLine("selected");
            //        StatusConsole.CloseFlyout();
            //    };

            //Console.WriteLine(@"ShowDpSelectDialog Done!");

            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            Console.WriteLine(@"DepartmentSelectDialog Initialized.");
            if (dlg.ShowDialog()) {
                Console.WriteLine(@"Dlg Shown.");
                selectedRow.Department = dlg.SelectedDpvm.Model;
            }
        }

        protected override OperatingPost GetNewItemInstance()
        {
            //get index
            int no = 1001;
            try
            {
                no = Math.Max(Model.Max(o => int.Parse(o.OperatingPostNo)), no);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            OperatingPost opp = new OperatingPost
            {
                Employees = new List<Employee>(),
                OperatingPostNo = (no + 1).ToString()
            };
            return opp;
        }
    }
}
