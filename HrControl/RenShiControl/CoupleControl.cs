using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HrControl
{
    public class CoupleControl : EntityControl<Couple>
    {
        protected override bool DeleteProtected(Couple t)
        {
            return true;
        }

        protected override void InitLogNeed(Couple t)
        {
            ParaList.Clear();
            ParaList.Add("添加夫妻关系");
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           
        }
    }
}
