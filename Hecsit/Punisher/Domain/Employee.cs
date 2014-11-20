using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain
{
    public class Employee
    {
        public string FIO { get; set; }
        public string PersonnelNumber { get; set; }
        public string RecruitmentDate { get; set; }
        public int Reputation { get; set; }

        public string Position { get; set; }
        public decimal WageRate { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
        }
    }
}
