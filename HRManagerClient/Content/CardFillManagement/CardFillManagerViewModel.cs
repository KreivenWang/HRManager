using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Steelsa.Localization;

namespace HRManagerClient
{
    class CardFillManagerViewModel : DBOperateViewModel<CardFillRecord>
    {
        public bool CanModify
        {
            get { return ModelSource.CurrentUser.SystemRole.Enabled_CardFill; }
        }

        public ICommand SelectEpCommand { get; set; }
        public IEnumerable CardFillRecordItems
        {
            get { return this.GetEnumLocalizedItems<CardFillRecordType>(); }
        }

        public CardFillManagerViewModel(EntityCollection<CardFillRecord> model)
            : base(model)
        {
            SelectEpCommand = new RelayCommand<CardFillRecord>(SelectEp);
        }

        private void SelectEp(CardFillRecord selectedCFR)
        {
            EmployeeSelectDialog dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog())
            {
                selectedCFR.Employee = dlg.SelectedEp;
            }
        }

        protected override void CreateItemSubmit()
        {
            if (CreatingItem.Employee == null)
                MessageBox.Show("员工未选.");
            else
                base.CreateItemSubmit();
        }

        protected override CardFillRecord GetNewItemInstance()
        {
            return new CardFillRecord { CardFillRecordType = CardFillRecordType.Personal};
        }
    }
}
