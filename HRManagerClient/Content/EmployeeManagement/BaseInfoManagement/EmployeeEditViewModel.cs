using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HRManagerClient.Utility;
using HRModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace HRManagerClient
{
    class EmployeeEditViewModel : ViewModelBase<Employee>
    {
        public bool IsSubmitted { get; private set; }
        /// <summary>
        /// 员工信息更新标记
        /// </summary>
        public static readonly string DetailChangedToken = "DetailChangedToken";

        #region IsCreateStatus 属性
        private bool _backfield_IsCreateStatus;
        public bool IsCreateStatus
        {
            get { return _backfield_IsCreateStatus; }
            set
            {
                _backfield_IsCreateStatus = value;
                RaisePropertyChanged("IsCreateStatus");
                RaisePropertyChanged("Title");
                RaisePropertyChanged("IsDepartmentSelected");
            }
        }
        #endregion

        #region Photo 属性
        private ImageSource  _backfield_Photo;
        public ImageSource Photo
        {
            get { return _backfield_Photo; }
            set
            {
                _backfield_Photo = value;
                RaisePropertyChanged("Photo");
            }
        }
        #endregion

        #region BelongDepartment 属性
        public Department BelongDepartment
        {
            get { return Model.Department; }
            set
            {
                Model.Department = value;
                RaisePropertyChanged(() => BelongDepartment);
                RaisePropertyChanged(() => IsDepartmentSelected);
                RaisePropertyChanged(() => OppItems);
            }
        }
        #endregion

        #region SelectedCoupleEp 属性
        private Employee _backfield_SelectedCoupleEp;
        public Employee SelectedCoupleEp
        {
            get { return _backfield_SelectedCoupleEp; }
            set
            {
                _backfield_SelectedCoupleEp = value;
                RaisePropertyChanged(() => SelectedCoupleEp);
            }
        }
        #endregion

        public bool IsDepartmentSelected
        {
            get
            {
                return BelongDepartment != null && IsCreateStatus;
            }
        }
        public IEnumerable OppItems
        {
            get
            {
                return ModelSource.OperatingPosts.Where(o => o.Department == BelongDepartment);
            }
        }

        public IEnumerable NationItems
        {
            get
            {
                return ModelSource.SystemArguments.Where(o => o.ArguType == ArguType.Nation);
            }
        }

        public IEnumerable EduItems
        {
            get
            {
                return ModelSource.SystemArguments.Where(o => o.ArguType == ArguType.EduBack);
            }
        }

        public ICommand BrowsePhotoCommand { get; set; }
        public ICommand DepartmentSelectCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }


        #region SelectEp 命令
        private ICommand _cmdSelectEp;
        public ICommand SelectEpCommand => _cmdSelectEp ?? (_cmdSelectEp = new RelayCommand(SelectEp));

        private void SelectEp()
        {
            var dlg = new EmployeeSelectDialog();
            if (dlg.ShowDialog()) {
                SelectedCoupleEp = dlg.SelectedEp;
            }
        }

        #endregion


        #region ClearEp 命令
        private ICommand _cmdClearEp;
        public ICommand ClearEpCommand => _cmdClearEp ?? (_cmdClearEp = new RelayCommand(ClearEp));

        private void ClearEp()
        {
            SelectedCoupleEp = null;
        }

        #endregion

        public string Title
        {
            get { return IsCreateStatus ? "人员信息[新建]" : "人员信息[编辑]"; }
        }

        public EmployeeEditViewModel(Employee model, bool isCreateStatus)
            : base(model)
        {
            IsCreateStatus = isCreateStatus;
            DepartmentSelectCommand = new RelayCommand(SelectDepartmentExecute);
            BrowsePhotoCommand = new RelayCommand(ShowBrowsePhotoDialog);
            if (!string.IsNullOrEmpty(Model.EmployeeBaseInfo.UserPhoto)) {
                Photo = Model.EmployeeBaseInfo.UserPhoto.ToImage().ToImageSource();
            }
            if (Model.ExpireDate == null)
                Model.ExpireDate = DateTime.Now.ToString();
            if (Model.HireDate == null)
                Model.HireDate = DateTime.Now.ToString();
            if (Model.EmployeeBaseInfo.Birthday == null)
                Model.EmployeeBaseInfo.Birthday = DateTime.Now.ToString();

            SelectedCoupleEp = Mate;
        }

        private Employee Mate
        {
            get
            {
                var foundCp = ModelSource.Couples.ToList()
                    .Find(c => c.EmployeeNan == Model || c.EmployeeNv == Model);
                if (foundCp == null) return null;
                return foundCp.EmployeeNan == Model ? foundCp.EmployeeNv : foundCp.EmployeeNan;
            }
        }

        internal bool UpdateItem()
        {
            if (Model.Department == null)
            {
                MessageBox.Show("部门不能为空!");
            }
            else if (Model.OperatingPost == null)
            {
                MessageBox.Show("岗位不能为空!");
            }
            else if (Model.EmployeeBaseInfo.EmployName == null)
            {
                MessageBox.Show("姓名不能为空!");
            }
            else if (Model.EmployeeNO == null)
            {
                MessageBox.Show("工号不能为空!");
            }
            else if (Model.HireDate == null)
            {
                MessageBox.Show("入职时间不能为空!");
            }
            else if (Model.ExpireDate == null)
            {
                MessageBox.Show("合同到期日不能为空!");
            }
            else if (Model.EmployeeBaseInfo.Birthday == null)
            {
                MessageBox.Show("生日不能为空!");
            }
            else
            {
                SendSignal(DetailChangedToken);
                if (SelectedCoupleEp != null) {
                    if (Mate != SelectedCoupleEp && Mate != null) { //huan yige 
                        RemoveExistCouple();
                        AddNewCouple();
                    }else if (Mate == null) { // 没有到有
                        AddNewCouple();
                    }
                } else { //到没有
                    RemoveExistCouple();
                }
                IsSubmitted = true;
                return true;
            }
            return false;
        }

        private void AddNewCouple()
        {
            var cp = new Couple {
                EmployeeNan = Model.EmployeeBaseInfo.Sex == SexEnum.Male ? Model : SelectedCoupleEp,
                EmployeeNv = Model.EmployeeBaseInfo.Sex == SexEnum.Male ? SelectedCoupleEp : Model
            };
            ModelSource.Couples.AddWithEntity(cp);
        }

        private void RemoveExistCouple()
        {
            var foundCp = ModelSource.Couples.ToList().Find(c => c.EmployeeNan == Model || c.EmployeeNv == Model);
            if (foundCp != null)
                ModelSource.Couples.RemoveWithEntity(foundCp);
        }

        private void SelectDepartmentExecute()
        {
            //sent a request to mainview
            //or just a static call
            DepartmentSelectDialog dlg = new DepartmentSelectDialog();
            if (dlg.ShowDialog()) {
                BelongDepartment = dlg.SelectedDpvm.Model;
            }
        }

        private void ShowBrowsePhotoDialog()
        {
            ImageBrowseDialog dlg = new ImageBrowseDialog();
            Image img;
            Console.WriteLine(@"ImageBrowseDialog Initialized.");
            if (dlg.ShowDialog(out img)) {
                Console.WriteLine(@"ImageBrowseDialog Shown.");
                Model.EmployeeBaseInfo.UserPhoto = img.ToBase64String();
                Photo = img.ToImageSource();
            }
        }

        public static bool ShowDetailDialog(Employee m, bool isCreateStatus)
        {
            var vm = new EmployeeEditViewModel(m, isCreateStatus);
            var v = new EmployeeEditDialog {DataContext = vm};
            v.ShowDialog();
            return vm.IsSubmitted;
        }
    }

    class MartialToCoupleChooseConverter : IValueConverter
    {
        #region IValueConverter 成员

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (MarriageEnum)value == MarriageEnum.Married ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
