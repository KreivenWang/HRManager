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
    class ReSignInManagerViewModel : DBOperateViewModel<ReSignIn>
    {
        public ReSignInManagerViewModel(EntityCollection<ReSignIn> model)
            : base(model)
        {
        }

        protected override void AddItem()
        {
            var dlg = new CreateReSignInDialog(new ReSignIn());
            if (dlg.ShowDialog())
            {
                foreach (var selectedEmployee in dlg.SelectedEmployees)
                {
                    var akl = (dlg.ModelExample as ReSignIn).Clone();
                    akl.Employee = selectedEmployee;
                    Model.AddWithEntity(akl);
                    System.Diagnostics.Trace.WriteLine("DBData Added!", typeof(ReSignIn).Name);
                }
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("DBData Add FAIL!", typeof(ReSignIn).Name);
            }
        }
    }
}
