using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HRManagerClient.Utility
{
    /// <summary>
    /// T 为 指定集合的内容类型
    /// </summary>
    public abstract class DBOperateViewModel<T> : ViewModelBase<EntityCollection<T>> 
        where T : class
    {
        public Type RealModelType { get { return typeof (T); } }

        #region SelectedItem 属性
        private T _backfield_SelectedItem;
        public virtual T SelectedItem
        {
            get { return _backfield_SelectedItem; }
            set
            {
                _backfield_SelectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }
        #endregion

        #region CreatingItem 属性
        private T _backfield_CreatingItem;
        public T CreatingItem
        {
            get { return _backfield_CreatingItem; }
            set
            {
                _backfield_CreatingItem = value;
                RaisePropertyChanged(() => CreatingItem);
            }
        }
        #endregion

        public ICommand AddItemCommand { get; private set; }
        public ICommand RemoveItemCommand { get; private set; }
        public ICommand UpdateItemCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public ICommand CreateItemCommand { get; private set; }
        public ICommand CreateSubmitCommand { get; private set; }

        public DBOperateViewModel(EntityCollection<T> model)
            : base(model)
        {
            AddItemCommand = new RelayCommand(AddItem);
            RemoveItemCommand = new RelayCommand(RemoveItem, RemoveItemCanExecute);
            UpdateItemCommand = new RelayCommand(SaveChanges, () => !Model.IsCreatingMode);
            RefreshCommand = new RelayCommand(Refresh, () => !Model.IsCreatingMode);

            CreateItemCommand = new RelayCommand(CreateItem, () => !Model.IsCreatingMode);
            CreateSubmitCommand = new RelayCommand(CreateItemSubmit, () => Model.IsCreatingMode);
        }

        protected virtual void CreateItem()
        {
            CreatingItem = Model.AddTempNewItem(GetNewItemInstance());
        }

        protected virtual void CreateItemSubmit()
        {
            Model.CreateSubmit();
        }

        protected void Refresh()
        {
            Model.RefreshData();
            System.Diagnostics.Trace.WriteLine("DBData Refreshed!", typeof(T).Name + Model);
        }

        protected virtual void RemoveItem()
        {
            if (Model.RemoveWithEntity(SelectedItem)) {
                System.Diagnostics.Trace.WriteLine("DBData Removed!", typeof(T).Name);
            } else {
                System.Diagnostics.Trace.WriteLine("DBData Remove FAIL!", typeof(T).Name);
            }
        }

        protected virtual void AddItem()
        {
            T t = GetNewItemInstance();
            if (t != null) {
                Model.AddWithEntity(t);
                System.Diagnostics.Trace.WriteLine("DBData Added!", typeof(T).Name);
            } else {
                System.Diagnostics.Trace.WriteLine("DBData Add FAIL!", typeof(T).Name);
            }
        }

        protected void SaveChanges()
        {
            Model.UpdateEntity();
            System.Diagnostics.Trace.WriteLine("DBData Updated!", typeof(T).Name);
        }

        protected virtual bool RemoveItemCanExecute()
        {
            return SelectedItem != null && !Model.IsCreatingMode;
        }

        protected virtual T GetNewItemInstance()
        {
            throw new NotImplementedException("获取实例方法: 使用前必须重写该方法.");
        }
    }
}
