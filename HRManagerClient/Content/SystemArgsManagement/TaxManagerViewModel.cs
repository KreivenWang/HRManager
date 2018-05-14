using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using HrControl;
using Steelsa.Localization;

namespace HRManagerClient
{
    class TaxManagerViewModel : ViewModelBase<TaxControl>
    {
        public Tax Arg
        {
            get { return Model.GetTaxArgu(); }
        }

        public ICommand SaveCommand { get; set; }
        public TaxManagerViewModel(TaxControl control)
            : base(control)
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save()
        {
            Model.UpdateTaxArgu(Arg);
        }
    }
}
