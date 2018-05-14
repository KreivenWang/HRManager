using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class BaseSalary
    {

        /// <summary>
        /// 社保
        /// </summary>
        public double SocialSecurity { get; set; }

        // 话费
        public double PhoneCost { get; set; }

        // 其他扣款
        public double OtherDeductions { get; set; }

        /// <summary>
        /// 伙食费系数
        /// </summary>
        public double BoardWages { get; set; }

        /// <summary>
        /// 全勤奖
        /// </summary>
        public double TotalOnDutyAllowance { get; set; }


        /// <summary>
        /// 夜班津贴
        /// </summary>
        public double NightAllowance { get; set; }

        /// <summary>
        /// 环境津贴
        /// </summary>
        public double EnvironmentalAllowance { get; set; }

        /// <summary>
        /// 工龄津贴
        /// </summary>
        public double WorkAgeAllowance { get; set; }

        /// <summary>
        /// 工龄津贴最大值
        /// </summary>
        public double WorkAgeAllowanceMax { get; set; }


        /// <summary>
        /// 特殊岗位津贴
        /// </summary>
        public double SpecialPostAllowance { get; set; }

        /// <summary>
        /// 高温津贴
        /// </summary>
        public double GaoWenAllowance { get; set; }


        /// <summary>
        /// 夫妻津贴
        /// </summary>
        public double CoupleAllowance { get; set; }

        private static BaseSalary baseSalary;

        public static BaseSalary GetInstance()
        {
            if (baseSalary == null)
            {
                try
                {
                    baseSalary = SerializeHelper.DeSerialize<BaseSalary>("baseSalary.data");
                }
                catch (IOException)
                {
                    baseSalary = new BaseSalary();
                }
            }
                
            return baseSalary;
        }
    }
}
