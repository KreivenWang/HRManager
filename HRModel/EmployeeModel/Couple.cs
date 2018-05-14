using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRModel
{
    public class Couple : IViewNeededModel
    {
        public int Id
        {
            get
            {
                return CoupleId;
            }
        }

        public int CoupleId { get; set; }


        public Employee EmployeeNan { get; set; }

        public Employee EmployeeNv { get; set; }
    }
}
