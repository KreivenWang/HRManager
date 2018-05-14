using HRManagerClient.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Steelsa.Localization;

namespace HRManagerClient
{
    class PostTransferAddViewModel : ViewModelBase<EmployeePostAdjust>
    {
        public IEnumerable RankItems
        {
            get
            {
                return this.GetEnumLocalizedItems<RankStatusEnum>();
            }
        }

        //public ICommand SelectEpCommand { get; set; }
        public ICommand SelectPostCommand { get; set; }

        public PostTransferAddViewModel(EmployeePostAdjust model)
            : base(model)
        {
            //SelectEpCommand = new RelayCommand(SelectEp);
            SelectPostCommand = new RelayCommand(PostSelect);
            SelectEp();
        }

        private void SelectEp()
        {
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog()) {
                Model = new EmployeePostAdjust();
                Model.Employee = dlg.SelectedEp;

                Model.PrevDepartment = dlg.SelectedEp.Department;
                Model.PrevOperatingPost = dlg.SelectedEp.OperatingPost;
                Model.RankStatus = RankStatusEnum.Even;
                Model.AdjustDateTime = DateTime.Now.ToShortDateString();
            }
        }

        private void PostSelect()
        {
            PostSelectDialog dlg = new PostSelectDialog();
            if (dlg.ShowDialog()) {
                Model.CurDepartment = dlg.SelectedOpp.Department;
                Model.CurOperatingPost = dlg.SelectedOpp;
            }
        }

        internal bool GetCompleteInfo()
        {
            return Model != null && Model.CurOperatingPost != null;
        }
    }
}
