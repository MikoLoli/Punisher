using System;

namespace Punisher.Domain
{
    public class EmployeeAction : Entity
    {
	    public virtual Employee Employee { get; set; }
	    public virtual DateTime Date { get; set; }
        public virtual string Description { get; set; }
	    public virtual ActionType Type { get; set; }
	    public virtual Measure Measure { get; set; }

        public EmployeeAction()
        {
        }

        public EmployeeAction(Employee employee, DateTime date, string description, ActionType type)
	    {
		    Employee = employee;
		    Date = date;
		    Description = description;
		    Type = type;
	    }

        public override string ToString()
        {
            return string.Format("Сотрудник : {0}\nДата деяния : {1}\nОписание : {2}\nТип : {3}\n", Employee.FIO, Date, Description, Type);
        }
    }
}
