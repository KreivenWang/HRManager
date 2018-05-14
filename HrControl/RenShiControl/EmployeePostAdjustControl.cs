using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl.RenShiControl
{
    public class EmployeePostAdjustControl : EntityControl<EmployeePostAdjust>
    {
        protected override void InitLogNeed(EmployeePostAdjust t)
        {
            ParaList.Clear();
            ParaList.Add("岗位调整 for");
            if (t.PrevOperatingPost != null)
            ParaList.Add(t.Employee.EmployeeBaseInfo.EmployName);
            ParaList.Add("原岗位");
            if (t.PrevOperatingPost!=null)
            ParaList.Add(t.PrevOperatingPost.OperatingPostName);
            ParaList.Add("现岗位");
            ParaList.Add(t.CurOperatingPost.OperatingPostName);
        }

        public override bool AddEntity(EmployeePostAdjust t)
        {
            t.Employee.Department = t.CurDepartment;
            t.Employee.OperatingPost = t.CurOperatingPost;
            return base.AddEntity(t);
        }

        protected override bool DeleteProtected(EmployeePostAdjust t)
        {
            return true;
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            
        }
    }
}
