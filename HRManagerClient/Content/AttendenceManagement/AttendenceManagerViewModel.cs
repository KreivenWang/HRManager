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
using System.Windows.Data;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Steelsa.Localization;

namespace HRManagerClient
{
    class AttendenceManagerViewModel : ViewModelBase<ObservableCollection<Attendance>>
    {

        #region FiltedItems 属性

        private IEnumerable _backfield_FiltedItems;

        public IEnumerable FiltedItems
        {
            get { return _backfield_FiltedItems; }
            set
            {
                _backfield_FiltedItems = value;
                RaisePropertyChanged(() => FiltedItems);
            }
        }

        #endregion

        #region StartTime 属性

        private DateTime _backfield_StartTime;

        public DateTime StartTime
        {
            get { return _backfield_StartTime; }
            set
            {
                _backfield_StartTime = value;
                RaisePropertyChanged(() => StartTime);
            }
        }

        #endregion

        #region EndTime 属性

        private DateTime _backfield_EndTime;

        public DateTime EndTime
        {
            get { return _backfield_EndTime; }
            set
            {
                _backfield_EndTime = value;
                RaisePropertyChanged(() => EndTime);
            }
        }

        #endregion

        public bool CanModify
        {
            get { return ModelSource.CurrentUser.SystemRole.Enabled_CardFill; }
        }

        #region Filte 命令

        private ICommand _cmdFilte;
        public ICommand FilteCommand => _cmdFilte ?? (_cmdFilte = new RelayCommand(Filte));

        private  void Filte()
        {
            if (EndTime < StartTime) {
                //await (Application.Current.MainWindow as MetroWindow).ShowMessageAsync("日期错误", "起始日期必须小于终止日期");
                MessageBox.Show("起始日期必须小于终止日期", "日期错误");
                FiltedItems = Model;
            }
            else {
                FiltedItems = Model.Where(m => m.RecordTimeToDateTime >= StartTime && m.RecordTimeToDateTime <= EndTime);
            }
        }

        #endregion

        #region ClearFilte 命令
        private ICommand _cmdClearFilte;
        public ICommand ClearFilteCommand => _cmdClearFilte ?? (_cmdClearFilte = new RelayCommand(ClearFilte));

        private void ClearFilte()
        {
            FiltedItems = Model;
            StartTime = DateTime.Now;
            EndTime = StartTime;
        }

        #endregion

        public AttendenceManagerViewModel(ObservableCollection<Attendance> model)
            : base(model)
        {
            ClearFilte();
        }
    }
}
