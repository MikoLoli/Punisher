using System;
using System.Collections.Generic;

namespace Punisher.Domain
{
    public class Employee
    {
		private readonly List<EmployeeAction> _employeeActions = new List<EmployeeAction>();

        public string FIO { get; set; }
        public string PersonnelNumber { get; set; }
        public DateTime RecruitmentDate { get; set; }
        public int Reputation { get; set; }

        public string Position { get; set; }
        public decimal WageRate { get; set; }
        public decimal Salary { get; set; }

	    public IEnumerable<EmployeeAction> EmployeeActions
	    {
		    get { return _employeeActions; }
	    }

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

        public void AddAction(EmployeeAction action)
        {
            _employeeActions.Add(action);
        }
    }
}
