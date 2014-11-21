
namespace Punisher.Domain
{
    public class ActionType : Entity
    {
	    private string Name { get; set; }
	    private MeasureType WeakMeasure { get; set; }
	    private MeasureType StrongMeasure { get; set; }

	    public ActionType(string name, MeasureType weakMeasure, MeasureType strongMeasure)
	    {
		    Name = name;
		    WeakMeasure = weakMeasure;
		    StrongMeasure = strongMeasure;
	    }
    }
}
