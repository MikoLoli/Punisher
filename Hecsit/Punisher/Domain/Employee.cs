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
        public DateTime RecruitmentDate { get; set; }
        public int Reputation { get; set; }

        public string Position { get; set; }
        public decimal WageRate { get; set; }
        public decimal Salary { get; set; }
        public List <EmployeeAction> EmployeeActions = new List<EmployeeAction>();

        public Employee( string fio, string personnelNumber, DateTime recruitmentDate, 
            int reputation, string position, decimal wageRate, decimal salary)
        {
            this.FIO = fio;
            this.PersonnelNumber = personnelNumber;
            this.RecruitmentDate = recruitmentDate;
            this.Reputation = reputation;
            this.Position = position;
            this.WageRate = wageRate;
            this.Salary = salary;
        }

        public void AddActionToEmployee(EmployeeAction employeeAction)
        {
            this.EmployeeActions.Add(employeeAction);
        }
    }
}
