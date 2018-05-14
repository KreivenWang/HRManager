using GalaSoft.MvvmLight.Command;
using HRModel;
using MahApps.Metro.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace HRManagerClient
{
    /// <summary>
    /// PostSelectDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PostSelectDialog : MetroWindow, INotifyPropertyChanged
    {
        public IEnumerable FiltedItems
        {
            get
            {
                IEnumerable<OperatingPost> filtered = Oppvms;
                if (!String.IsNullOrEmpty(NameFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.OperatingPostName)
                        && item.OperatingPostName.Contains(NameFilterText));
                }
                if (!String.IsNullOrEmpty(PostNoFilterText)) {
                    filtered = filtered.Where(item => !String.IsNullOrWhiteSpace(item.OperatingPostNo) && item.OperatingPostNo.Contains(PostNoFilterText));
                }
                if (DpFilter != null) {
                    filtered = filtered.Where(item => item.Department == DpFilter);
                }
                return filtered;
            }
        }

        #region PostNoFilterText 属性
        private string _backfield_PostNoFilterText;
        public string PostNoFilterText
        {
            get { return _backfield_PostNoFilterText; }
            set
            {
                _backfield_PostNoFilterText = value;
                OnPropertyChanged("PostNoFilterText");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region NameFilterText 属性
        private string _backfield_NameFilterText;
        public string NameFilterText
        {
            get { return _backfield_NameFilterText; }
            set
            {
                _backfield_NameFilterText = value;
                OnPropertyChanged("NameFilterText");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region DpFilter 属性
        private Department _backfield_DpFilter;
        public Department DpFilter
        {
            get { return _backfield_DpFilter; }
            set
            {
                _backfield_DpFilter = value;
                OnPropertyChanged("DpFilter");
                OnPropertyChanged("FiltedItems");
            }
        }
        #endregion

        #region IsDpFilterEditable 属性
        private bool _backfield_IsDpFilterEditable;
        public bool IsDpFilterEditable
        {
            get { return _backfield_IsDpFilterEditable; }
            set
            {
                _backfield_IsDpFilterEditable = value;
                OnPropertyChanged("IsDpFilterEditable");
            }
        }
        #endregion

        public OperatingPost SelectedOpp { get; set; }
        public ObservableCollection<OperatingPost> Oppvms { get; set; }
        public PostSelectDialog()
        {
            InitializeComponent();
            Oppvms = new ObservableCollection<OperatingPost>(ModelSource.OperatingPosts.ToList());
            this.DataContext = this;
        }
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectedOpp != null)
                this.Close();
        }

        public new bool ShowDialog()
        {
            base.ShowDialog();
            return SelectedOpp != null;
        }

        #region INotifyPropertyChanged 成员

        [field: NonSerializedAttribute()]//非序列化字段
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        private void SelectDp_Click(object sender, RoutedEventArgs e)
        {
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog()) {
                DpFilter = dlg.SelectedDpvm.Model;
            }
        }

        private void ClearSelectedDp_Click(object sender, RoutedEventArgs e)
        {
            DpFilter = null;
        }
    }
}
