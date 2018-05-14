using System;
using System.Collections.Generic;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class DepartmentControl : EntityControl<Department>
    {
        public DepartmentControl()
        {
            //Factory = new EntityDataFactory<Department>(HrManagerContext.GetInstance().Departments);
        }

        protected override void InitLogNeed(Department t)
        {
            ParaList.Clear();
            ParaList.Add("部门");
            ParaList.Add(t.DepartName);
            ParaList.Add(t.DepartNo);
        }

        protected override bool DeleteProtected(Department t)
        {
            if (t.Employees.Count > 0)
                return false;
            else
                return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            LogAccess.Write(type + GetLogContent() +'\t' + "该部门下还有员工");
        }
    }
}
