using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using Steelsa.Localization;

namespace HRManagerClient
{
    class SystemArgsManagerViewModel : DBOperateViewModel<SystemArgument>
    {
        //public ObservableCollection<SystemArgument> FiltedItems { get; private set; } 

        public IEnumerable FiltedItems
        {
            get { return ShowAll ? Model : Model.Where(s => s.ArguType == ArgsTypeFilter); }
        }

        public IEnumerable ArgsTypeItems
        {
            get { return this.GetEnumLocalizedItems<ArguType>(); }
        }

        #region ArgsTypeFilter 属性
        private ArguType _backfield_ArgsTypeFilter;

        public ArguType ArgsTypeFilter
        {
            get { return _backfield_ArgsTypeFilter; }
            set
            {
                _backfield_ArgsTypeFilter = value;
                RaisePropertyChanged(() => ArgsTypeFilter);
                RaisePropertyChanged(() => FiltedItems);
            }
        }

        #endregion

        #region ShowAll 属性
        private bool _backfield_ShowAll;
        public bool ShowAll
        {
            get { return _backfield_ShowAll; }
            set
            {
                _backfield_ShowAll = value;
                RaisePropertyChanged(() => ShowAll);
                RaisePropertyChanged(() => FiltedItems);
            }
        }
        #endregion

        public SystemArgsManagerViewModel(EntityCollection<SystemArgument> model)
            : base(model)
        {
            ShowAll = true;
            AskLeaveTypesManagerVM = new AskLeaveTypesManagerVM(ModelSource.AskLeaveTypes); 
        }

        protected override SystemArgument GetNewItemInstance()
        {
            return new SystemArgument(){ ArguType = ArguType.ReSignInReasonType};
        }

        #region AskLeaveTypePart

        public AskLeaveTypesManagerVM AskLeaveTypesManagerVM { get; set; }

        #endregion
    }

    class AskLeaveTypesManagerVM : DBOperateViewModel<AskLeaveType>
    {
        public AskLeaveTypesManagerVM(EntityCollection<AskLeaveType> model) : base(model)
        {
        }

        protected override AskLeaveType GetNewItemInstance()
        {
            return new AskLeaveType();
        }
    }
}
