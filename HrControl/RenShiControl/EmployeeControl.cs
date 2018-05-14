using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class EmployeeControl : EntityControl<Employee>
    {
        
        public EmployeeControl()
        {
            //Factory = new EntityDataFactory<Employee>(HrManagerContext.GetInstance().Employees);
        }
        protected override void InitLogNeed(Employee t)
        {
            ParaList.Clear();
            ParaList.Add("员工");
            ParaList.Add(t.EmployeeBaseInfo.EmployName);
            ParaList.Add(t.EmployeeNO);
        }

        protected override bool DeleteProtected(Employee t)
        {
         
            var attendances = HrManagerContext.GetInstance().Attendances.ToList().Any(a => a.EmployeeNo == t.EmployeeNO && a.RecordTimeToDateTime.Month == DateTime.Now.Month);
            return !attendances;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            LogAccess.Write(type + GetLogContent() + '\t' + "该员工存该月存在打卡记录,不能删除");
        }
    }
}
