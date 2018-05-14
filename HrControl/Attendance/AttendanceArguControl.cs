using HRModel;

namespace HrControl
{
    public class AttendanceArguControl
    {
        public AttendanceArgu GetAttendanceArgu()
        {
            return AttendanceArgu.GetInstance();
        }

        public void UpdateAttendanceArgu(AttendanceArgu attendanceArgu)
        {
            SerializeHelper.Serialize(attendanceArgu, AttendanceArgu.FileName);
        }
    }

}
