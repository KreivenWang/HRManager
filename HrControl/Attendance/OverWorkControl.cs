using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class OverWorkControl : EntityControl<OverWork>
    {
        protected override void InitLogNeed(OverWork t)
        {
           ParaList.Clear();
            ParaList.Add("加班");
            ParaList.Add(t.Employee.EmployeeNO);
            ParaList.Add(t.Employee.EmployeeBaseInfo.EmployName);

        }

        protected override bool DeleteProtected(OverWork t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           
        }

        public void ImportData(IEnumerable<OverWork> ows)
        {
            var ist = HrManagerContext.GetInstance();
            ist.OverWorks.AddRange(ows);
            ist.SaveChanges();
        }
    }
}
