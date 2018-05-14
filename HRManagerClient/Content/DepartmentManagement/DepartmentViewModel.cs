using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HRManagerClient
{
    public class DepartmentViewModel : ViewModelBase<Department>
    {
        DepartmentManagerViewModel _parentManagerVM;

        public bool IsTopDp
        {
            get { return ParentDpvm == null; }
        }

        #region IsOnDuty 属性
        public bool IsOnDuty
        {
            get { return Model.IsOnDuty; }
            set
            {
                Model.IsOnDuty = value;
                RaisePropertyChanged("IsOnDuty");
            }
        }
        #endregion
        

        #region ParentDpvm 属性
        private DepartmentViewModel _backfield_ParentDpvm;
        public DepartmentViewModel ParentDpvm
        {
            get { return _backfield_ParentDpvm; }
            set
            {
                _backfield_ParentDpvm = value;
                RaisePropertyChanged("ParentDpvm");
                if (_backfield_ParentDpvm == null) {
                    Model.ParentDepartment = null;
                } else {
                    Model.ParentDepartment = _backfield_ParentDpvm.Model;
                }
                RaisePropertyChanged("ParentDpvm");
//                 if (_parentManagerVM != null)
//                     _parentManagerVM.UpdateItem();
            }
        }
        #endregion

        public ObservableCollection<DepartmentViewModel> ChildrenDpvms { get; set; }

        public DepartmentViewModel(Department model,DepartmentManagerViewModel parentvm)
            : base(model)
        {
            _parentManagerVM = parentvm;
            ChildrenDpvms = new ObservableCollection<DepartmentViewModel>();
        }

        internal void AddChildDepartment(DepartmentViewModel dpvm)
        {
            ChildrenDpvms.Add(dpvm);
//             if (_parentManagerVM != null)
//                 _parentManagerVM.UpdateItem();
            dpvm.ParentDpvm = this;
        }

        internal void RemoveChildDepartment(DepartmentViewModel dpvm)
        {
            ChildrenDpvms.Remove(dpvm);
//             if (_parentManagerVM != null)
//                 _parentManagerVM.UpdateItem();
            dpvm.ParentDpvm = null;
        }

        internal bool CanRecognizeChild(DepartmentViewModel childForCheck)
        {
            if (ChildrenDpvms.ToList().Contains(childForCheck)) {
                return true;
            } else {
                var result = false;
                foreach (var childDpvm in ChildrenDpvms) {
                    if (childDpvm.CanRecognizeChild(childForCheck))
                        result = true;
                }
                return result;
            }
        }
    }
}
