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
    class WorkArrangementAsignViewModel : DBOperateViewModel<ArrangeWork>
    {
        public IEnumerable AsignedItems
        {
            get
            {
                IEnumerable<ArrangeWork> filtered = Model.Where(w => !w.IsCommonDefine);
                return filtered;
            }
        }
        
        public WorkArrangementAsignViewModel(EntityCollection<ArrangeWork> model)
            : base(model)
        {
            
        }

        protected override ArrangeWork GetNewItemInstance()
        {
            WkarDefSelectDialog dlg = new WkarDefSelectDialog();
            if (dlg.ShowDialog()) {
                var result = dlg.SelectedWkar.Clone();
                dlg.SelectedWkar.Department = null;
                dlg.SelectedWkar.Employee = null;
                dlg.SelectedWkar.OperatingPost = null;
                return result;
            }
            return null;
        }
    }
}
