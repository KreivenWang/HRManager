using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
    public class ReSignInControl : EntityControl<ReSignIn>
    {
        protected override void InitLogNeed(ReSignIn t)
        {
           ParaList.Clear();
            ParaList.Add("补签");
            ParaList.Add(t.Employee.EmployeeNO);
            ParaList.Add(t.Employee.EmployeeBaseInfo.EmployName);

        }

        protected override bool DeleteProtected(ReSignIn t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           
        }
    }
}
