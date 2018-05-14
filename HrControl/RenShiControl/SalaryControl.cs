using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class SalaryControl : EntityControl<Salary>
    {

        public SalaryControl()
        {
            //Factory = new EntityDataFactory<Employee>(HrManagerContext.GetInstance().Employees);
        }
        protected override void InitLogNeed(Salary t)
        {
            ParaList.Clear();
            ParaList.Add("设置底薪");
            ParaList.Add(t.Employee.EmployeeBaseInfo.EmployName);
            ParaList.Add(t.Employee.EmployeeNO);
        }

        protected override bool DeleteProtected(Salary t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            
        }
    }
}
