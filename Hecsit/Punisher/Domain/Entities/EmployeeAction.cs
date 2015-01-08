using System;

namespace Punisher.Domain
{
    public class EmployeeAction : Entity
    {
	    public Employee Employee { get; set; }
	    public DateTime Date { get; set; }
        public string Description { get; set; }
	    public ActionType Type { get; set; }
	    public Measure Measure { get; set; }

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
