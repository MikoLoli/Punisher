using System;
using System.Collections.Generic;

namespace Punisher.Domain
{
    public class Employee : Entity
    {
		private readonly IList<EmployeeAction> _employeeActions = new List<EmployeeAction>();

        public virtual string FIO { get; set; }
        public virtual string PersonnelNumber { get; set; }
        public virtual DateTime RecruitmentDate { get; set; }
        public virtual int Reputation { get; set; }
        public virtual string Position { get; set; }
        public virtual decimal WageRate { get; set; }
        public virtual decimal Salary { get; set; }

	    public virtual IList<EmployeeAction> EmployeeActions
	    {
		    get { return _employeeActions; }
	    }

	    public Employee( string fio, string personnelNumber, DateTime recruitmentDate, 
            int reputation, string position, decimal wageRate, decimal salary)
        {
            FIO = fio;
            this.PersonnelNumber = personnelNumber;
            this.RecruitmentDate = recruitmentDate;
            this.Reputation = reputation;
            this.Position = position;
            this.WageRate = wageRate;
            this.Salary = salary;
        }

        public Employee()
        {
        }

        public virtual void AddAction(EmployeeAction action)
        {
            _employeeActions.Add(action);
        }
    }
}
