
namespace Punisher.Domain
{
    public class ActionType : Entity
    {
	    public virtual string Name { get; set; }
	    public virtual MeasureType WeakMeasure { get; set; }
	    public virtual MeasureType StrongMeasure { get; set; }

	    public ActionType(string name, MeasureType weakMeasure, MeasureType strongMeasure)
	    {
		    Name = name;
		    WeakMeasure = weakMeasure;
		    StrongMeasure = strongMeasure;
	    }

        public ActionType()
        {
        }

        public override string ToString()
        {
            return string.Format("Тип деяния : {0}\nСлабая мера : {1}\nЖесткая мера : {2}\n",Name,WeakMeasure,StrongMeasure);
        }
    }
}
