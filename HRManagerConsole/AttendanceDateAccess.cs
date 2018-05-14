using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRModel;

namespace HRManagerDataAccess
{
    public class AttendanceDateAccess
    {
        public List<Attendance> GetAttendancesByMonth(int month)
        {
            return HrManagerContext.GetInstance().Attendances.Where(a => a.RecordTimeToDateTime.Month == month).ToList();
        }


        public List<Employee> GetEmployeesLeaveThemSelveList()
        {
            return null;
        }
    }
}
