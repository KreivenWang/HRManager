using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl.RenShiControl
{
   public class NoticControl
    {
       public List<Employee> GetLastMonthLeaveEmployees()
       {
           return
               HrManagerContext.GetInstance()
                   .Employees.Where(e => DateTime.Parse(e.ExpireDate).Month < DateTime.Now.Month)
                   .ToList();
       } 

      
    }
}
