using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrControl;
using HRManagerDataAccess;
using HRModel;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            AttendanceResultControl wrapper = new AttendanceResultControl();

            wrapper.Analysis(new DateTime(2016,4,1));
        }
    }
}
