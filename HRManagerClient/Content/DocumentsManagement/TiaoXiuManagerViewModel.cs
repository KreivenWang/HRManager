using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HRManagerClient
{
    class TiaoXiuManagerViewModel : DBOperateViewModel<TiaoXiu>
    {
        public ICommand SelectEpCommand { get; set; }
        public ICommand ClearEpCommand { get; set; }



        public TiaoXiuManagerViewModel(EntityCollection<TiaoXiu> model)
            : base(model)
        {
            SelectEpCommand = new RelayCommand(ShowEpSelectDialog);
            ClearEpCommand = new RelayCommand(ClearSelectedEp);
        }


        private void ClearSelectedEp()
        {
            SelectedItem.Employee = null;
        }

        private void ShowEpSelectDialog()
        {
            if (SelectedItem == null)
                return;
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog())
                SelectedItem.Employee = dlg.SelectedEp;
        }

        //protected override TiaoXiu GetNewItemInstance()
        //{
        //    //get index
        //    int no = 1001;
        //    try {
        //        no = Math.Max(Model.Max(o => int.Parse(o.TiaoXiuNo)), no);
        //    } catch (Exception ex) {
        //        System.Diagnostics.Trace.WriteLine(ex.Message);
        //    }
        //    return new TiaoXiu { TiaoXiuNo = (no + 1).ToString() };
        //}

        protected override void AddItem()
        {
            CreateTiaoXiuDialog dlg = new CreateTiaoXiuDialog(new TiaoXiu());
            if (dlg.ShowDialog()) {
                foreach (var selectedEmployee in dlg.SelectedEmployees) {
                    var tiaoXiu = (dlg.ModelExample as TiaoXiu).Clone();
                    tiaoXiu.Employee = selectedEmployee;
                    Model.AddWithEntity(tiaoXiu);
                    System.Diagnostics.Trace.WriteLine("DBData Added!", typeof(TiaoXiu).Name);
                }
            } else {
                System.Diagnostics.Trace.WriteLine("DBData Add FAIL!", typeof(TiaoXiu).Name);
            }
        }
    }
}
