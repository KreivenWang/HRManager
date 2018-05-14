using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class VacationPlanControl : EntityControl<VacationPlan>
    {
        protected override void InitLogNeed(VacationPlan t)
        {
            ParaList.Add("节假日方案");
            ParaList.Add(t.PlanName);
        }

        protected override bool DeleteProtected(VacationPlan t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
           
        }

        //public override bool AddEntity(VacationPlan t)
        //{
        //    var vacations = HrManagerContext.GetInstance().VacationPlans;
        //    if (vacations.Any(v => v.EmployeeId == t.EmployeeId))
        //        this.DeleteEntity(vacations.Single(v => v.EmployeeId == t.EmployeeId));
        //    if (vacations.Any(v => v.OperatingPostId == t.OperatingPostId))
        //        this.DeleteEntity(vacations.Single(v => v.DepartmentId == t.DepartmentId));
        //    if (vacations.Any(v => v.DepartmentId == t.DepartmentId))
        //        this.DeleteEntity(vacations.Single(v => v.DepartmentId == t.DepartmentId));
        //    if(vacations.Any(v => v.IsCommonDefine))
        //        this.DeleteEntity(vacations.Single(v => v.IsCommonDefine));
        //    return base.AddEntity(t);
        //}
    }
}
