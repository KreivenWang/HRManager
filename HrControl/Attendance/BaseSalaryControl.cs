using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HrControl
{
    public class BaseSalaryControl
    {

        public BaseSalary GetAttendanceArgu()
        {
            return BaseSalary.GetInstance();
        }

        public void UpdateAttendanceArgu(BaseSalary attendanceArgu)
        {
            SerializeHelper.Serialize(attendanceArgu, "baseSalary.data");
        }
    }
}
