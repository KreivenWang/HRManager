using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HRManagerClient.Utility
{
    public abstract class ViewModelBase<M> : ViewModelBase
    {
        #region Model 属性
        private M _backfield_Model;
        public M Model
        {
            get { return _backfield_Model; }
            set
            {
                _backfield_Model = value;
                RaisePropertyChanged(() => Model);
            }
        }
        #endregion

        public ICommand LoadingRowEventToCommand { get; set; }

        /// <summary>
        /// Model初始化为空的构造方法
        /// </summary>
        protected ViewModelBase()
            : this(default(M))
        {
            
        }

        /// <summary>
        /// 带Model的构造方法
        /// </summary>
        /// <param name="model"></param>
        protected ViewModelBase(M model)
        {
            Model = model;
            LoadingRowEventToCommand = new RelayCommand<DataGridRowEventArgs>(OnDataGridLoadingRow);
        }

        private void OnDataGridLoadingRow(DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }

        /// <summary>
        /// 注册接受指定标记信号的槽, 使用指定action处理
        /// </summary>
        protected void RegistReceiverSlot(object token, Action action)
        {
            if (_actions == null) 
                _actions = new Dictionary<object, Action>();
            _actions.Add(token, action);
            Messenger.Default.Register<object>(this, token, ReceiverSlot);
        }

        private Dictionary<object, Action> _actions;
        private void ReceiverSlot(object token)
        {
            if (_actions[token] != null)
                _actions[token]();
        }

        /// <summary>
        /// 发射指定标记的信号
        /// </summary>
        protected void SendSignal(object token)
        {
            Messenger.Default.Send(token, token);
        }

        protected async void DoProgress(Action action, string msg = "正在执行", string title = "请稍后")
        {
            var window = Application.Current.MainWindow as MetroWindow;
            var controller =
                await
                    window.ShowProgressAsync(title, msg, false,
                        new LoginDialogSettings { AnimateShow = false });
            controller.SetIndeterminate();
            await Task.Factory.StartNew(action);
            await controller.CloseAsync();
        }
    }
}
