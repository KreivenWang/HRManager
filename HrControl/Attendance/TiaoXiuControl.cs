using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HrControl
{
    public class TiaoXiuControl : EntityControl<TiaoXiu>
    {
        protected override bool DeleteProtected(TiaoXiu t)
        {
            return true;
        }

        protected override void InitLogNeed(TiaoXiu t)
        {
            ParaList.Clear();
            ParaList.Add("调休管理");
            ParaList.Add(t.TiaoXiuNo);

        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           
        }
    }
}
