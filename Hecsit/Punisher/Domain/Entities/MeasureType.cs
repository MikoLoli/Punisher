
namespace Punisher.Domain
{
    public class MeasureType : Entity
    {
	    public string Name { get; set; }
	    public MeasureKind Kind { get; set; }
	    public int Score { get; set; }

	    public MeasureType(string name, MeasureKind kind, int score)
	    {
		    Name = name;
		    Kind = kind;
		    Score = score;
	    }
    }
}
