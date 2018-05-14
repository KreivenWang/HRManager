using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class Tax
    {
        /// <summary>
        /// 住房公积金个人比例
        /// </summary>
        public double PresonRatio { get; set; }


        /// <summary>
        /// 起征点
        /// </summary>
        public double Threshold { get; set; }


        /// <summary>
        /// 分割线
        /// </summary>
        public double CutOffRule { get; set; }

        /// <summary>
        /// 大于分割线的税率
        /// </summary>
        public double OverCutOffRuleRatio { get; set; }

        /// <summary>
        /// 低于分割线的税率
        /// </summary>
        public double UnderCutOffRuleRatio { get; set; }

        /// <summary>
        /// 固定值
        /// </summary>
        public double FixedValue { get; set; }


        private static Tax tax;

        public static Tax GetInstance()
        {
            if (tax == null) {
                try {
                    tax = SerializeHelper.DeSerialize<Tax>("tax.data");
                } catch (IOException) {
                    tax = new Tax();
                }
            }

            return tax;
        }
    }
}
