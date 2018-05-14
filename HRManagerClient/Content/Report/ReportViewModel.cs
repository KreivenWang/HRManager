using GalaSoft.MvvmLight.Command;
using HRManagerClient.Utility;
using System;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HRManagerClient
{
    class ReportViewModel<T> : ViewModelBase<ObservableCollection<T>>
    {
        protected Type ReportType { get { return typeof (T); }}

        #region ExportCsv 命令
        private ICommand _cmdExportCsv;
        public ICommand ExportCsvCommand => _cmdExportCsv ?? (_cmdExportCsv = new RelayCommand<DataGrid>(ExportCsv));

        private void ExportCsv(DataGrid dataGrid)
        {
            dataGrid.ExportDataGridSaveAs(true);
       }

        #endregion

        public ReportViewModel(ObservableCollection<T> model)
            : base(model)
        {
            
        }
    }
}
