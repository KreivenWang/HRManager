using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class Dormitory : IViewNeededModel
    {
        public int DormitoryId { get; set; }

        /// <summary>
        /// 所属员工
        /// </summary>
        public virtual Employee Employee { get; set; }

        public int? EmployeeId { get; set; }

        /// <summary>
        /// 宿舍号
        /// </summary>
        [StringLength(50)]
        public string DormitoryNo { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        [StringLength(50)]
        public string BedNo { get; set; }

        /// <summary>
        /// 是否是空闲的 true 空闲 false已分配
        /// </summary>
        public bool  IsAvailable { get; set; }

        [NotMapped]
        public int Id { get { return DormitoryId; } }
    }
}
