
namespace Punisher.Domain
{
    public class ActionType : Entity
    {
	    public string Name { get; set; }
	    public MeasureType WeakMeasure { get; set; }
	    public MeasureType StrongMeasure { get; set; }

	    public ActionType(string name, MeasureType weakMeasure, MeasureType strongMeasure)
	    {
		    Name = name;
		    WeakMeasure = weakMeasure;
		    StrongMeasure = strongMeasure;
	    }

        public override string ToString()
        {
            return string.Format("Тип деяния : {0}\nСлабая мера : {1}\nЖесткая мера : {2}\n",Name,WeakMeasure,StrongMeasure);
        }
    }
}
