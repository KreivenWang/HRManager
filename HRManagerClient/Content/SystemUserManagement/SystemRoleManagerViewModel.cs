using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Steelsa.Localization;

namespace HRManagerClient
{
    class SystemRoleManagerViewModel : DBOperateViewModel<SystemRole>
    {
        public bool CanModify
        {
            get { return ModelSource.CurrentUser.SystemRole.Enabled_SystemUser; }
        }
        //public ICommand SelectEpCommand { get; set; }
        public IEnumerable SystemRoleItems
        {
            get { return ModelSource.SystemRoles; }
        }

        public SystemRoleManagerViewModel(EntityCollection<SystemRole> model)
            : base(model)
        {
            //SelectEpCommand = new RelayCommand<CardFillRecord>(SelectEp);
        }

        protected override void CreateItemSubmit()
        {
            if (CreatingItem.Name == null)
                MessageBox.Show("角色名未填写.");
            else
                base.CreateItemSubmit();
        }

        protected override bool RemoveItemCanExecute()
        {
            return base.RemoveItemCanExecute() && !SelectedItem.IsDefaultRole;
        }

        public void OnAutoGeneratingColumn(DataGridAutoGeneratingColumnEventArgs e)
        {
//             if (e.PropertyName == "Name"
//                 || e.PropertyName == "Creator"
//                 || e.PropertyName == "SystemRoleId"
//                 || e.PropertyName == "IsActive"
//                 || e.PropertyName == "CreateTime")
//             {
//                 e.Cancel = true;
//             }
        }

        public void OnLoadingRow(DataGridRowEventArgs e)
        {
            var role = e.Row.DataContext as SystemRole;
            e.Row.IsEnabled = !role.IsDefaultRole;
        }

        protected override SystemRole GetNewItemInstance()
        {
            return new SystemRole() { Creator = ModelSource.CurrentUser.UserName, CreateTime = DateTime.Now.ToString() };
        }
    }
}
