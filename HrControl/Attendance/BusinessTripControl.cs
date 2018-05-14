using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
    public class BusinessTripControl : EntityControl<BusinessTrip>
    {
        protected override void InitLogNeed(BusinessTrip t)
        {
           ParaList.Clear();
            ParaList.Add("出差");
            ParaList.Add(t.Employee.EmployeeNO);
            ParaList.Add(t.Employee.EmployeeBaseInfo.EmployName);

        }

        protected override bool DeleteProtected(BusinessTrip t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           
        }
    }
}
