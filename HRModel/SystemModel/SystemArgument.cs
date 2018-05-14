using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{

    public enum ArguType
    {
        Nation, //民族
        EduBack, //学历
        ReSignInReasonType, //补签原因
        ReSignInType, //补签类型
        OverWorkType, //加班类型
    }


    public  class SystemArgument  : IViewNeededModel
    {
        [NotMapped]
        public int Id { get { return SystemArgumentId; } }


        public int SystemArgumentId { get; set; }


        /// <summary>
        /// 参数名字
        /// </summary>
        [StringLength(50)]
        public string ArguValue { get; set; }

        /// <summary>
        /// 参数类型
        /// </summary>
        public ArguType ArguType { get; set; }

        /// <summary>
        /// 参数助记码
        /// </summary>
        //[StringLength(50)]
        //public string ArguKey { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
         [StringLength(50)]
        public string State { get; set; }
    }
}
