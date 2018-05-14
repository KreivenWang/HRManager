using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public class EmployeeProfileReport : EmployeeReport
    {
        [Localize("身份证")]
        public string IdentityCard
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.IdentityCard; }
        }

        [Localize("性别")]
        public string Sex
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Sex.EnumLocalize(); }
        }

        [Localize("生日")]
        public string Birthday
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Birthday.ToShortDate(); }
        }

        [Localize("民族")]
        public string Nationality
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Nationality; }
        }

        [Localize("联系电话")]
        public string Phone
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Phone; }
        }

        [Localize("婚否")]
        public string Marriage
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Marital.EnumLocalize(); }
        }
        [Localize("籍贯")]
        public string FamilyPlace
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.FamilyPlace; }
        }

        [Localize("毕业院校")]
        public string Graduate
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Graduate; }
        }

        [Localize("学历")]
        public string Culture
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Culture; }
        }

        [Localize("专业")]
        public string Profession
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Profession; }
        }

        [Localize("合同到期日")]
        public string ExpireDate
        {
            get { return Employee == null ? null : Employee.ExpireDate.ToShortDate(); }
        }

        [Localize("户口所在地")]
        public string AccountSite
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.AccountSite; }
        }

        [Localize("现住址")]
        public string CurSite
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.CurSite; }
        }

        [Localize("紧急联系人")]
        public string EmergencyName
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.EmergencyName; }
        }

        [Localize("联系人电话")]
        public string EmergencyPhoneNumber
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.EmergencyPhoneNumber; }
        }

        [Localize("联系人地址")]
        public string EmergencySite
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.EmergencySite; }
        }

        [Localize("入职日期")]
        public string HireDate
        {
            get { return Employee == null ? null : Employee.HireDate.ToShortDate(); }
        }

        [Localize("人员状态")]
        public string State
        {
            get { return Employee == null ? null : Employee.State.EnumLocalize(); }
        }

        [Localize("备注")]
        public string Remark
        {
            get { return Employee == null || Employee.EmployeeBaseInfo == null ? null : Employee.EmployeeBaseInfo.Remark; }
        }
    }
}
