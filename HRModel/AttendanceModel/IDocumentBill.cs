using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModel
{
    /// <summary>
    /// 单据: 加班单 请假单 出差单 补签单等
    /// </summary>
    public interface IDocumentBill
    {
        /// <summary>
        /// 制单人
        /// </summary>
        string Creator { get; set; }
    }
}
