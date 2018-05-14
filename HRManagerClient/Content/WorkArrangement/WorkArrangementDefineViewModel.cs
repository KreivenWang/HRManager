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
using Steelsa.Localization;

namespace HRManagerClient
{
    class WorkArrangementDefineViewModel : DBOperateViewModel<ArrangeWork>
    {
//         public IEnumerable DefinedItems
//         {
//             get
//             {
//                 List<ArrangeWork> filtered = Model.Where(w => w.IsCommonDefine).ToList();
//                 return filtered;
//             }
//         }

        public IEnumerable SpanTypeItems
        {
            get { return this.GetEnumLocalizedItems<ArrangeWorkTimeSpanType>(); }
        }

        public ICommand DpSelectCommand { get; set; }
        public ICommand ClearSelectedDpCommand { get; set; }
        public WorkArrangementDefineViewModel(EntityCollection<ArrangeWork> model)
            : base(model)
        {
            DpSelectCommand = new RelayCommand<OperatingPost>(ShowDpSelectDialog);
            ClearSelectedDpCommand = new RelayCommand<OperatingPost>(ClearDpSelectDialog);
        }

        private void ClearDpSelectDialog(OperatingPost selectedRow)
        {
            selectedRow.Department = null;
        }

        private void ShowDpSelectDialog(OperatingPost selectedRow)
        {
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog())
                selectedRow.Department = dlg.SelectedDpvm.Model;
        }

//         protected override void RemoveItem()
//         {
//             base.RemoveItem();
//             RaisePropertyChanged(() => DefinedItems);
//         }
// 
//         protected override void AddItem()
//         {
//             base.AddItem();
//             RaisePropertyChanged(() => DefinedItems);
//         }

        protected override ArrangeWork GetNewItemInstance()
        {
            //get index
            int no = 1001;
            try {
                no = Math.Max(Model.Max(o => int.Parse(o.ArrangeWorkNo)), no);
            } catch (Exception ex) {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
            var aw = new ArrangeWork {ArrangeWorkNo = (no + 1).ToString() };
            return aw;
        }
    }
}
