using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Steelsa.Localization;

namespace HRModel
{
    public class EmployeeTransferReport : EmployeeReport
    {
        [Localize("原部门")]
        public string PrevDepartment { get; set; }
        [Localize("原岗位")]
        public string PrevPost { get; set; }
        [Localize("现部门")]
        public string CurDepartment { get; set; }

        [Localize("现岗位")]
        public string CurPost { get; set; }

        [Localize("调整状态")]
        public string RankStatus { get; set; }

        [Localize("调整时间")]
        public string TransferTime { get; set; }
    }
}
