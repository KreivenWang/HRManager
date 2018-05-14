using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
    /// <summary>
    /// 排班管理
    /// </summary>
    public class ArrangeWorkControl : EntityControl<ArrangeWork>
    {

        protected override void InitLogNeed(ArrangeWork t)
        {
            ParaList.Clear();
            ParaList.Add(t.ArrangeWorkNo);
            ParaList.Add(t.WorkName);
        }

        protected override bool DeleteProtected(ArrangeWork t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            
        }
    }
}
