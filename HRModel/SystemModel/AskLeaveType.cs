using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class AskLeaveType : IViewNeededModel
    {
        [NotMapped]
        public int Id { get { return AskLeaveTypeId; } }


        public int AskLeaveTypeId   { get; set; }


        public string LeaveName { get; set; }

        /// <summary>
        /// 是否带薪休假
        /// </summary>
        public bool  IsWithPay { get; set; }


    }
}
