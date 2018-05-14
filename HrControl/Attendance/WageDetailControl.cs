using HRManagerDataAccess;
using HRModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HrControl
{
    public class WageDetailControl : EntityControl<WageDetail>
    {
        protected override bool DeleteProtected(WageDetail t)
        {
            return true;
        }

        protected override void InitLogNeed(WageDetail t)
        {
            ParaList.Clear();
            ParaList.Add("薪资更新");
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            
        }


        public void Analysis(DateTime now)
        {
            try
            {
                CalculateWage wage = new CalculateWage();
                var wages = wage.getWages(now);
                HrManagerContext.GetInstance().WageDetails.AddRange(wages);
                HrManagerContext.GetInstance().SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
           
        }
    }
}
