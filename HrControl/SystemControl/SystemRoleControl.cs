using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class SystemRoleControl : EntityControl<SystemRole>
   {
        protected override void InitLogNeed(SystemRole t)
       {
           ParaList.Clear();
           ParaList.Add("系统角色");
           ParaList.Add(t.Name);
       }

        protected override bool DeleteProtected(SystemRole t)
       {
           return true;
       }

       protected override void WriteDeleteProtectedLog(string type)
       {
       }
   }
}
