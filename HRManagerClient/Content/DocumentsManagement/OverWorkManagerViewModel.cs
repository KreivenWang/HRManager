using System;
using System.Collections.Generic;
using System.Linq;
using HRManagerClient.Utility;
using HRModel;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using HrControl;
using Steelsa;
using MessageBox = System.Windows.MessageBox;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace HRManagerClient
{
    class OverWorkManagerViewModel : DBOperateViewModel<OverWork>
    {
        const string startImportStr = "开始导入";

        #region ImportButtonContent 属性
        private string _backfield_ImportButtonContent;
        public string ImportButtonContent
        {
            get { return _backfield_ImportButtonContent; }
            set
            {
                _backfield_ImportButtonContent = value;
                RaisePropertyChanged(() => ImportButtonContent);
            }
        }
        #endregion

        #region ExcelPath 属性
        private string _backfield_ExcelPath;
        public string ExcelPath
        {
            get { return _backfield_ExcelPath; }
            set
            {
                _backfield_ExcelPath = value;
                RaisePropertyChanged(() => ExcelPath);
                if (!File.Exists(value)) {
                    ImportButtonContent = "浏览Excel加班单文件";
                } else {
                    ImportButtonContent = startImportStr;
                }
            }
        }
        #endregion

        #region Import 命令
        private ICommand _cmdImport;
        public ICommand ImportCommand => _cmdImport ?? (_cmdImport = new RelayCommand(Import));

        private void Import()
        {
            if (ImportButtonContent == startImportStr) {
                DoProgress(delegate
                {
                    var dataSet = LoadDataFromExcel();
                    FillData(dataSet);
                },"正在导入...");
            } else {
                using (var dialog = new System.Windows.Forms.OpenFileDialog() { DefaultExt = "xls"}) {
                    if (dialog.ShowDialog() == DialogResult.OK && dialog.FileName != null) {
                        ExcelPath = dialog.FileName;
                    }
                }
            }
        }

        #endregion

        public OverWorkManagerViewModel(EntityCollection<OverWork> model)
            : base(model)
        {
            ExcelPath = string.Empty;
            //ExcelPath = @"C:\Users\Kreiven\Desktop\OverWorkSample.xls";
        }

        protected override void AddItem()
        {
            var dlg = new CreateOverWorkDialog(new OverWork());
            if (dlg.ShowDialog())
            {
                foreach (var selectedEmployee in dlg.SelectedEmployees)
                {
                    var ow = (dlg.ModelExample as OverWork).Clone();
                    ow.Employee = selectedEmployee;
                    ow.IsOnDuty = dlg.IsOnDutyFall;
                    ow.IsOffDuty = dlg.IsOffdutyFall;
                    Model.AddWithEntity(ow);
                    System.Diagnostics.Trace.WriteLine("DBData Added!", typeof(OverWork).Name);
                }
            }
            else
            {
                System.Diagnostics.Trace.WriteLine("DBData Add FAIL!", typeof(OverWork).Name);
            }
        }

        //加载Excel   
        public DataSet LoadDataFromExcel()
        {
            /*
             * 参数HDR的值：
             * HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。
             * IMEX:
             * 0 is Export mode, 只能写入
             * 1 is Import mode, 只能读取
             * 2 is Linked mode (full update capabilities)
             */
            try {
                //strConn = "Provider=Microsoft.Jet.Oledb.4.0; Data Source=" + filePath + "; Extended Properties=\"Excel 8.0; HDR=No; IMEX=1;\"";
                var srcTabelName = "Sheet1$";
                var OleConn = new OleDbConnection($@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={ExcelPath};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'");
                OleConn.Open();
                string sql = $"SELECT * FROM  [{srcTabelName}]";//可是更改Sheet名称，比如sheet2，等等   
                var OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                var dataSet = new DataSet();
                OleDaExcel.Fill(dataSet, srcTabelName);
                OleConn.Close();
                return dataSet;
            } catch (Exception err) {
                MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息");
                return null;
            }
        }

        public void FillData(DataSet dataSet)
        {
            var curColumn = 0;
            var curRow = 0;
            var showRoCo = true;
            try {
                var owList = new List<OverWork>();
                var dataTable = dataSet.Tables[0];
                for (; curRow < dataTable.Rows.Count; curRow++) {
                    curColumn = 0;
                    showRoCo = true;
                    var number = dataTable.Rows[curRow][curColumn++]?.ToString();
                    var epNo = dataTable.Rows[curRow][curColumn++]?.ToString();
                    var epName = dataTable.Rows[curRow][curColumn++]?.ToString();
                    var startTime = DateTime.Parse(dataTable.Rows[curRow][curColumn++]?.ToString());
                    var endTime = DateTime.Parse(dataTable.Rows[curRow][curColumn++]?.ToString());
                    var applyTime = int.Parse(dataTable.Rows[curRow][curColumn++].ToString());
                    //var reduceTime = DateTime.Parse(dataTable.Rows[ro][curColumn++]?.ToString());
                    var typeOverWork = dataTable.Rows[curRow][curColumn++]?.ToString();
                    var IsOnduty = int.Parse(dataTable.Rows[curRow][curColumn++].ToString());
                    var IsOffduty = int.Parse(dataTable.Rows[curRow][curColumn++].ToString());
                    var description = dataTable.Rows[curRow][curColumn++]?.ToString();
                    var creator = dataTable.Rows[curRow][curColumn]?.ToString();
                    showRoCo = false;

                    var foundEp =
                        ModelSource.Employees.ToList()
                            .Find(ep => ep.EmployeeNO == epNo && ep.EmployeeBaseInfo.EmployName == epName);
                    if (foundEp == null)
                        throw new Exception($"未找到员工:{epNo}/{epName}");

                    var o = new OverWork {
                        Number = number,
                        Employee = foundEp,
                        BeginDateTime = startTime.ToString(CultureInfo.InvariantCulture),
                        EndDateTime = endTime.ToString(CultureInfo.InvariantCulture),
                        ApplyTime = applyTime.ToString(),
                        //ReduceTime = reduceTime.ToString(CultureInfo.InvariantCulture),
                        OverWorkType = typeOverWork,
                        IsOnDuty = IsOnduty.ParseToBoolean(),
                        IsOffDuty = IsOffduty.ParseToBoolean(),
                        Description = description,
                        Creator = creator
                    };
                    owList.Add(o);
                    ModelSource.OverWorks.AddWithoutEntity(o);
                    //Console.WriteLine(cellValue is DBNull ? "Empty" : cellValue);
                }
                (ModelSource.OverWorks.EntityCtrl as OverWorkControl)?.ImportData(owList);
            } catch (Exception exception) {
                //第一行为列名, 第二行开始; 代码从0开始, 显示从1开始;  计算列时catch之前已经被++,所以不用+1
                var failTip = showRoCo? $"(行:{curRow + 2} 列:{curColumn})" : string.Empty; 
                MessageBox.Show($"{exception.Message}\r\n{failTip}", "加班单导入失败!");
                StatusConsole.WriteLine("加班单导入失败! " + failTip);
            }
        }
    }

    public static class BooleanExtension
    {
        public static bool ParseToBoolean(this int i)
        {
            if (i == 1) {
                return true;
            } else if (i == 0) {
                return false;
            }
            throw new Exception("所需值必须为 1 或 0!");
        }
    }

    
}
