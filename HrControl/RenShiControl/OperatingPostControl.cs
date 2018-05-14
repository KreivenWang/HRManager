using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class OperatingPostControl  : EntityControl<OperatingPost>
    {
        public OperatingPostControl()
        {
            //Factory = new EntityDataFactory<OperatingPost>(HrManagerContext.GetInstance().OperatingPosts);
        }

        protected override void InitLogNeed(OperatingPost t)
        {
            ParaList.Clear();
            ParaList.Add("岗位");
            ParaList.Add(t.OperatingPostNo);
            ParaList.Add(t.OperatingPostName);
        }

        protected override bool DeleteProtected(OperatingPost t)
        {
            if (t.Employees.Count > 0)
                return false;
            else
            {
                return true;
            }
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           LogAccess.Write("该岗位还有员工,无法删除");
        }
    }
}
