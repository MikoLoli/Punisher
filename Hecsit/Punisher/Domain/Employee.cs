using System;
using System.Collections.Generic;

namespace Punisher.Domain
{
    public class Employee : Entity
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

        public Employee()
        {
        }

        public void AddAction(EmployeeAction action)
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
