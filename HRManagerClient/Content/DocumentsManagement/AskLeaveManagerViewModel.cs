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
    class AskLeaveManagerViewModel : DBOperateViewModel<AskLeave>
    {
        public AskLeaveManagerViewModel(EntityCollection<AskLeave> model)
            : base(model)
        {
        }

        protected override void AddItem()
        {
            CreateAskLeaveDialog dlg = new CreateAskLeaveDialog(new AskLeave());
            if (dlg.ShowDialog())
            {
                foreach (var selectedEmployee in dlg.SelectedEmployees)
                {
                    var akl = (dlg.ModelExample as AskLeave).Clone();
                    akl.Employee = selectedEmployee;
                    Model.AddWithEntity(akl);
                    System.Diagnostics.Trace.WriteLine("DBData Added!", typeof(AskLeave).Name);
                }
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("DBData Add FAIL!", typeof(AskLeave).Name);
            }
        }
    }
}
