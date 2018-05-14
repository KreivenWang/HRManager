using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HRManagerClient
{
    public class DepartmentManagerViewModel : ViewModelBase<EntityCollection<Department>>
    {
        const string RootDpStr = "部门信息";


        #region EditBorderColor 属性
        private SolidColorBrush _backfield_EditBorderColor;
        public SolidColorBrush EditBorderColor
        {
            get { return _backfield_EditBorderColor; }
            set
            {
                _backfield_EditBorderColor = value;
                RaisePropertyChanged("EditBorderColor");
            }
        }
        #endregion

        #region EditBackgroundColor 属性
        private SolidColorBrush _backfield_EditBackgroundColor;
        public SolidColorBrush EditBackgroundColor
        {
            get { return _backfield_EditBackgroundColor; }
            set
            {
                _backfield_EditBackgroundColor = value;
                RaisePropertyChanged("EditBackgroundColor");
            }
        }
        #endregion

        #region SelectedDp 属性
        private DepartmentViewModel _backfield_SelectedDp;
        public DepartmentViewModel SelectedDp
        {
            get { return _backfield_SelectedDp; }
            set
            {
                _backfield_SelectedDp = value;
                RaisePropertyChanged("SelectedDp");
            }
        }
        #endregion

        #region IsEditing 属性
        private bool _backfield_IsEditing;
        public bool IsEditing
        {
            get { return _backfield_IsEditing; }
            set
            {
                _backfield_IsEditing = value;
                RaisePropertyChanged("IsEditing");
                EditBorderColor = _backfield_IsEditing ? Brushes.Chocolate : Brushes.DimGray;
                EditBackgroundColor = _backfield_IsEditing ? Brushes.AliceBlue : Brushes.LightGray;
            }
        }
        #endregion

        public ObservableCollection<DepartmentViewModel> TopDepartmentVMs { get; set; }
        public ObservableCollection<DepartmentViewModel> DepartmentVMs_RootOnly { get; set; }
        public ICommand AddNewTopDpCommand { get; set; }
        public ICommand AddNewSubDpCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }
        public ICommand RemoveDpCommand { get; set; }

        public DepartmentManagerViewModel(EntityCollection<Department> model)
            : base(model)
        {
            TopDepartmentVMs = new ObservableCollection<DepartmentViewModel>();
            TopDepartmentVMs.BuildDpVM_TreeStructs(Model, null, this);

            AddNewTopDpCommand = new RelayCommand(AddNewTopDepartment, () => IsEditing);
            AddNewSubDpCommand = new RelayCommand(AddNewSubDepartment, AddSubDepartment_CanExec);
            SaveChangesCommand = new RelayCommand(UpdateItem);
            RemoveDpCommand = new RelayCommand(RemoveDepartment, RemoveDepartment_CanExec);
            SelectTreeNodeCommand = new RelayCommand<MouseButtonEventArgs>(TreeNodeSelected);
            DropCommand = new RelayCommand<DragEventArgs>(DropExecute);
            IsEditing = false;
        }

        private bool AddSubDepartment_CanExec()
        {
            return SelectedDp != null && IsEditing;
        }

        private bool RemoveDepartment_CanExec()
        {
            return SelectedDp != null && IsEditing && SelectedDp.Model.Employees.Count == 0;
        }

        private void RemoveDepartment()
        {
            //move children to Top
            foreach (var childDpvm in SelectedDp.ChildrenDpvms) {
                childDpvm.ParentDpvm = null;
                TopDepartmentVMs.Add(childDpvm);
            }
            SelectedDp.ChildrenDpvms.Clear();

            //remove
            RemoveDpvm(SelectedDp);
            Model.RemoveWithEntity(SelectedDp.Model);
        }

        private void AddNewSubDepartment()
        {
            var newDpvm = GetNewDepartmentVM();
            newDpvm.Model.DepartName = "SubDp";
            Model.AddWithEntity(newDpvm.Model);
            AddDpvm(newDpvm, SelectedDp);
        }

        private void AddNewTopDepartment()
        {
            var newTopDpvm = GetNewDepartmentVM();
            newTopDpvm.Model.DepartName = "TopDp";
            Model.AddWithEntity(newTopDpvm.Model);
            AddDpvm(newTopDpvm, null);
        }

        internal void UpdateItem()
        {
            Model.UpdateEntity();
        }

        /// <summary>
        /// to == null: toTop
        /// </summary>
        private void AddDpvm(DepartmentViewModel from, DepartmentViewModel to)
        {
            if (to == null) {
                TopDepartmentVMs.Add(from);
            } else {
                to.AddChildDepartment(from);
            }
        }

        private void RemoveDpvm(DepartmentViewModel dpvm)
        {
            if (dpvm.IsTopDp) {
                TopDepartmentVMs.Remove(dpvm);
            } else {
                dpvm.ParentDpvm.RemoveChildDepartment(dpvm);
            }
        }

        private DepartmentViewModel GetNewDepartmentVM()
        {
            List<Employee> employees = new List<Employee>();
            var dp = new Department() { Employees = employees, IsOnDuty = true};
            return new DepartmentViewModel(dp, this);
        }

        public ICommand SelectTreeNodeCommand { get; set; }
        public ICommand DropCommand { get; set; }

        private void TreeNodeSelected(MouseButtonEventArgs e)
        {
            SelectedDp = null;
            if (e.LeftButton == MouseButtonState.Pressed || e.RightButton == MouseButtonState.Pressed) {
                var treeViewItem = VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
                if (treeViewItem != null) {
                    treeViewItem.IsSelected = true;
                    SelectedDp = treeViewItem.DataContext as DepartmentViewModel;
                    if (e.LeftButton == MouseButtonState.Pressed && SelectedDp != null && IsEditing) {
                        DragDrop.DoDragDrop(treeViewItem, SelectedDp, DragDropEffects.Copy);
                    }
                    e.Handled = true;
                }
            }
        }

        private void DropExecute(DragEventArgs e)
        {
            var data = e.Data; 
            var dropTarget = VisualHelper.VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (data.GetDataPresent(typeof(DepartmentViewModel))) {
                var dragSrcDpvm = data.GetData(typeof(DepartmentViewModel)) as DepartmentViewModel;
                var targetDpvm = dropTarget.DataContext as DepartmentViewModel;
                //confirm 'from' and 'to'
                if (dragSrcDpvm != null && dragSrcDpvm == SelectedDp && dragSrcDpvm != targetDpvm) { 
                    //confirm not own child
                    if (!dragSrcDpvm.CanRecognizeChild(targetDpvm)) {
                        RemoveDpvm(dragSrcDpvm);
                        AddDpvm(dragSrcDpvm, targetDpvm);
                        dropTarget.IsSelected = true;
                        SelectedDp = targetDpvm;
                    }
                }
            }
        }
    }

    public static class DepartmentManagerViewModelExtension
    {
        public static void BuildDpVM_TreeStructs(this ObservableCollection<DepartmentViewModel> topDpvms, IEnumerable<Department> DpsSource, DepartmentViewModel parentDpvm = null, DepartmentManagerViewModel dpMgVm = null)
        {
            var foundChildren = DpsSource.ToList().FindAll(d => d.ParentDepartment == (parentDpvm == null ? null : parentDpvm.Model));
            foreach (var childDp in foundChildren) {
                var childDpvm = new DepartmentViewModel(childDp, dpMgVm);
                var from = childDpvm;
                var to = parentDpvm;
                if (to == null) {
                    topDpvms.Add(from);
                } else {
                    to.AddChildDepartment(from);
                }
                //AddDpvm(childDpvm, parentDpvm);
                topDpvms.BuildDpVM_TreeStructs(DpsSource, childDpvm, dpMgVm);
            }
        }
    }
}
