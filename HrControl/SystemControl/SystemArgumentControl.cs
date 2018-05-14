using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
   public class SystemArgumentControl  :EntityControl<SystemArgument>
   {
       protected override void InitLogNeed(SystemArgument t)
       {
           ParaList.Clear();
           ParaList.Add("参数");
           ParaList.Add(t.ArguValue);
       }

       protected override bool DeleteProtected(SystemArgument t)
       {
           return true;
       }

       protected override void WriteDeleteProtectedLog(string type)
       {
       }

       public static List<string> GetArguments(ArguType type)
       {
           return
               HrManagerContext.GetInstance()
                   .SystemArguments.Where(a => a.ArguType == type)
                   .ToList()
                   .ConvertAll(s => s.ArguValue);
       }



   }
}
