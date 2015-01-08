using System;
using System.Collections.Generic;

namespace Punisher.Domain
{
    public class Employee : Entity
    {
		private readonly List<EmployeeAction> _employeeActions = new List<EmployeeAction>();

        public virtual string FIO { get; set; }
        public virtual string PersonnelNumber { get; set; }
        public virtual DateTime RecruitmentDate { get; set; }
        public virtual int Reputation { get; set; }
        public virtual string Position { get; set; }
        public virtual decimal WageRate { get; set; }
        public virtual decimal Salary { get; set; }

	    public virtual IEnumerable<EmployeeAction> EmployeeActions
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

        public override string ToString()
        {
            return string.Format(" Сотрудник {0}\n Персональный номер: {1}\n Дата приема на работу: {2}\n " +
                                 "Репутация: {3}\n Должность: {4}\n Ставка: {5}\n Оклад: {6}$\n", FIO, 
                                 PersonnelNumber, RecruitmentDate, Reputation, Position, WageRate, Salary);
        }
    }
}
