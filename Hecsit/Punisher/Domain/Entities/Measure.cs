using System;

namespace Punisher.Domain
{
    public class Measure : Entity
    {
	    private bool _approved;

        public virtual DateTime Date { get; set; }
		public virtual string Description { get; set; }
	    public virtual MeasureType Type { get; set; }
	    public virtual bool Approved
	    {
		    get { return _approved; }
	    }
        public virtual Employee Employee { get; set; }

        public Measure()
        {
        }

        public Measure(DateTime date, string description, MeasureType type, Employee employee)
	    {
		    Date = date;
		    Description = description;
		    Type = type;
	        Employee = employee;
	    }

	    public virtual void Approve()
	    {
		    _approved = true;
		    Date = DateTime.Now;
	    }
    }
}
