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
using System.Windows.Media;
using Steelsa.Localization;
using System.Collections.ObjectModel;

namespace HRManagerClient
{
    class PostTransferManagerViewModel : DBOperateViewModel<EmployeePostAdjust>
    {
        public PostTransferManagerViewModel(EntityCollection<EmployeePostAdjust> model)
            : base(model)
        {
        }

        protected override EmployeePostAdjust GetNewItemInstance()
        {
            var vm = new PostTransferAddViewModel(null);
            if (vm.Model == null) return null;
            var dlg = new PostTransferAddDialog {DataContext = vm};
            if (dlg.ShowDialog()) {
                return vm.Model;
            }
            return null;
        }
    }
}
