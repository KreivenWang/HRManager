using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
   public class AskLeaveTypeControl : EntityControl<AskLeaveType>
    {
       protected override void InitLogNeed(AskLeaveType t)
       {
           ParaList.Clear();
            ParaList.Add("请假类型");
       }

       protected override bool DeleteProtected(AskLeaveType t)
       {
           return true;
       }

       protected override void WriteDeleteProtectedLog(string type)
       {
           
       }

       public static List<string> GetLeaveTypeNames()
       {
           return
               HrManagerContext.GetInstance()
                   .AskLeaveTypes
                   .ToList()
                   .ConvertAll(s => s.LeaveName);
       }
    }
}
