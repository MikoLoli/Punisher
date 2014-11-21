
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;
using Punisher.TestData;
using PunisherConsole.Actions;

namespace PunisherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
	        var repository = new MemoryRepository<MeasureType>();
	        var generator = new TestDataGenerator(repository);
			generator.Generate();

	        new MenuBuilder()
		        .Title("Hello World!")
		        .Prompt("Enter command")
		        .Item("View Measure Types", new ViewMeasureTypesAction(repository))
		        .Item("Second Item", new SecondAction())
		        .Exit("Exit")
		        .GetMenu()
		        .Run();
        }
    }
}
