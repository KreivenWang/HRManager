using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManagerDataAccess;
using HRModel;

namespace HrControl
{
    public class DormitoryControl : EntityControl<Dormitory>
    {
        public DormitoryControl()
        {
            //Factory = new EntityDataFactory<Dormitory>(HrManagerContext.GetInstance().Dormitorys);
        }
        protected override void InitLogNeed(Dormitory t)
        {
            ParaList.Clear();
            ParaList.Add("宿舍");
            ParaList.Add(t.DormitoryNo);
        }

        protected override bool DeleteProtected(Dormitory t)
        {
            if(t.IsAvailable)
            return true;
            else
            {
                return false;
            }
        }

        protected override void WriteDeleteProtectedLog(string type)
        {
            LogAccess.Write("该宿舍还有成员");
        }
    }
}
