using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
   public class AskLeaveControl :EntityControl<AskLeave>
    {
       protected override void InitLogNeed(AskLeave t)
       {
           ParaList.Clear();
           ParaList.Add("请假单");
       }

       protected override bool DeleteProtected(AskLeave t)
       {
           return true;
       }

       protected override void WriteDeleteProtectedLog(string type)
       {
           ;
       }
    }
}
