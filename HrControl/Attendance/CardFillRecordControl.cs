using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
    public class CardFillRecordControl : EntityControl<CardFillRecord>
    {
        protected override void InitLogNeed(CardFillRecord t)
        {
            ParaList.Clear();
            ParaList.Add("补卡");
            ParaList.Add(t.Employee.EmployeeNO);
            ParaList.Add(t.Employee.EmployeeBaseInfo.EmployName);

        }

        protected override bool DeleteProtected(CardFillRecord t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {

        }
    }
}
