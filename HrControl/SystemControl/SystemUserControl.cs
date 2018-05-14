using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class SystemUserControl : EntityControl<SystemUser>
   {
        protected override void InitLogNeed(SystemUser t)
       {
           ParaList.Clear();
           ParaList.Add("系统用户");
           ParaList.Add(t.UserName);
       }

       protected override bool DeleteProtected(SystemUser t)
       {
           return true;
       }

       protected override void WriteDeleteProtectedLog(string type)
       {
       }
   }
}
