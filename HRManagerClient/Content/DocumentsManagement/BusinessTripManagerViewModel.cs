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
    class BusinessTripManagerViewModel : DBOperateViewModel<BusinessTrip>
    {
        public BusinessTripManagerViewModel(EntityCollection<BusinessTrip> model)
            : base(model)
        {
        }

        protected override void AddItem()
        {
            var dlg = new CreateBusinessTripDialog(new BusinessTrip());
            if (dlg.ShowDialog())
            {
                foreach (var selectedEmployee in dlg.SelectedEmployees)
                {
                    var btp = (dlg.ModelExample as BusinessTrip).Clone();
                    btp.Employee = selectedEmployee;
                    Model.AddWithEntity(btp);
                    System.Diagnostics.Trace.WriteLine("DBData Added!", typeof(BusinessTrip).Name);
                }
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("DBData Add FAIL!", typeof(BusinessTrip).Name);
            }
        }
    }
}
