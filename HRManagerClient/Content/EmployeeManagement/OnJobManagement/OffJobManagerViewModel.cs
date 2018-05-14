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
    class OffJobManagerViewModel : DBOperateViewModel<Employee>
    {
        public ObservableCollection<Employee> LeftEps { get; set; }
        public OffJobManagerViewModel(EntityCollection<Employee> model)
            : base(model)
        {
            LeftEps = new ObservableCollection<Employee>(Model.Where(e => e.State == JobStatusEnum.Resigned).ToList());
        }
        
    }
}
