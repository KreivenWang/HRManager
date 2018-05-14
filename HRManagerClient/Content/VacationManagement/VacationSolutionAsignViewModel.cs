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

namespace HRManagerClient
{
    class VacationSolutionAsignViewModel : DBOperateViewModel<VacationPlan>
    {
        public IEnumerable AsignedItems
        {
            get
            {
                IEnumerable<VacationPlan> filtered = Model.Where(w => !w.IsCommonDefine);
                return filtered;
            }
        }

        public VacationSolutionAsignViewModel(EntityCollection<VacationPlan> model)
            : base(model)
        {
            
        }

        protected override VacationPlan GetNewItemInstance()
        {
            VacationPlanSelectDialog dlg = new VacationPlanSelectDialog();
            if (dlg.ShowDialog()) {
                var result = dlg.SelectedPlan.Clone();
                dlg.SelectedPlan.Department = null;
                dlg.SelectedPlan.Employee = null;
                dlg.SelectedPlan.OperatingPost = null;
                return result;
            }
            return null;
        }
    }
}
