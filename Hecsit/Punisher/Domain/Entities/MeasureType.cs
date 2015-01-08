
namespace Punisher.Domain
{
    public class MeasureType : Entity
    {
	    public virtual string Name { get; set; }
	    public virtual MeasureKind Kind { get; set; }
	    public virtual int Score { get; set; }

        public MeasureType()
        {
        }

        public MeasureType(string name, MeasureKind kind, int score)
	    {
		    Name = name;
		    Kind = kind;
		    Score = score;
	    }
    }
}
