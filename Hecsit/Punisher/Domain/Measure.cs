using System;

namespace Punisher.Domain
{
    public class Measure : Entity
    {
	    private bool _approved;

        public DateTime Date { get; set; }
        
		public string Description { get; set; }

	    public MeasureType Type { get; set; }

	    public bool Approved
	    {
		    get { return _approved; }
	    }

	    public Employee Employee { get; set; }

	    public Measure(DateTime date, string description, MeasureType type, Employee employee)
	    {
		    Date = date;
		    Description = description;
		    Type = type;
	        Employee = employee;
	    }

	    public void Approve()
	    {
		    _approved = true;
		    Date = DateTime.Now;
	    }
    }
}
