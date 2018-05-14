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
    class BaseSalarySetViewModel : DBOperateViewModel<Salary>
    {
        public bool CanModify
        {
            get { return ModelSource.CurrentUser.SystemRole.Enabled_BaseSalaryArgs; }
        }

        public IEnumerable SalaryTypeItems
        {
            get { return this.GetEnumLocalizedItems<SalaryType>(); }
        }

        public BaseSalarySetViewModel(EntityCollection<Salary> model)
            : base(model)
        {
            
        }

    }
}
