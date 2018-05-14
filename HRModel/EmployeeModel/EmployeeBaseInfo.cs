using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace HRModel
{
    public class EmployeeBaseInfo : ObservableObject, IViewNeededModel
    {

        #region 员工基本信息
        private string _employname;
        private SexEnum _sex;
        private string _nationality;
        private string _culture;
        private string _familyplace;
        private string _identitycard;
        private string _phone;

        private string _remark;
        private string _graduate;
        private string _profession;
        private string _cursite;
        private string _accountSite;
        private string _emergencyName;
        private string _emergencySite;
        private string _emergencyPhoneNumber;

        public int EmployeeBaseInfoId { get; set; }


        /// <summary>
        /// 员工名称
        /// </summary>
        [StringLength(50)]
        public string EmployName
        {
            set { _employname = value; }
            get { return _employname; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public SexEnum Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        [StringLength(50)]
        public string Nationality
        {
            set { _nationality = value; }
            get { return _nationality; }
        }

        #region Birthday 生日
        private string _backfield_Birthday;
        [StringLength(50)]

        public string Birthday
        {
            get { return _backfield_Birthday; }
            set
            {
                _backfield_Birthday = value;
                RaisePropertyChanged(() => Birthday);
            }
        }
        #endregion


        /// <summary>
        /// 学历
        /// </summary>
        [StringLength(50)]
        public string Culture
        {
            set { _culture = value; }
            get { return _culture; }
        }


        /// <summary>
        /// 毕业院校
        /// </summary>
        [StringLength(50)]
        public string Graduate
        {
            get { return _graduate; }
            set { _graduate = value; }
        }


        /// <summary>
        /// 专业
        /// </summary>
        [StringLength(50)]
        public string Profession
        {
            get { return _profession; }
            set { _profession = value; }
        }

        #region Marital 婚姻情况
        private MarriageEnum _backfield_Marital;
        public MarriageEnum Marital
        {
            get { return _backfield_Marital; }
            set
            {
                _backfield_Marital = value;
                RaisePropertyChanged(() => Marital);
            }
        }
        #endregion

        /// <summary>
        /// 惯籍
        /// </summary>
        [StringLength(50)]
        public string FamilyPlace
        {
            set { _familyplace = value; }
            get { return _familyplace; }
        }

        /// <summary>
        /// 现居地
        /// </summary>
        [StringLength(100)]
        public string CurSite
        {
            get { return _cursite; }
            set { _cursite = value; }
        }


        /// <summary>
        /// 户口地
        /// </summary>
        [StringLength(100)]
        public string AccountSite
        {
            get { return _accountSite; }
            set { _accountSite = value; }
        }



        /// <summary>
        /// 紧急联系人
        /// </summary>
        [StringLength(50)]
        public string EmergencyName
        {
            get { return _emergencyName; }
            set { _emergencyName = value; }
        }



        /// <summary>
        /// 紧急联系人地址
        /// </summary>
        [StringLength(100)]
        public string EmergencySite
        {
            get { return _emergencySite; }
            set { _emergencySite = value; }
        }



        /// <summary>
        /// 紧急联系人电话
        /// </summary>
        [StringLength(50)]
        public string EmergencyPhoneNumber
        {
            get { return _emergencyPhoneNumber; }
            set { _emergencyPhoneNumber = value; }
        }

        /// <summary>
        /// 身份证编号
        /// </summary>
        [StringLength(50)]
        public string IdentityCard
        {
            set { _identitycard = value; }
            get { return _identitycard; }
        }

        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(50)]
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }



        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200)]
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 用户头像 base64编码
        /// </summary>
        public string UserPhoto { get; set; }
        #endregion

        public int Id
        {
            get { return EmployeeBaseInfoId; }
        }
    }
}
