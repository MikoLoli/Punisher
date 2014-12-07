
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
            var employeeRep = new MemoryRepository<Employee>();
            var employeeActionRep = new MemoryRepository<EmployeeAction>();
            var actionTypeRep = new MemoryRepository<ActionType>();
            var measureTypeRep = new MemoryRepository<MeasureType>();
            var measureRep = new MemoryRepository<Measure>();
	        var generator = new TestDataGenerator(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep);
			generator.Generate();

	        new MenuBuilder()
		        .Title("Hello World!")
		        .Prompt("Enter command")
                .Item("View Measure Types", new ViewMeasureTypesAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
                .Item("Second Item", new SecondAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
		        .Exit("Exit")
		        .GetMenu()
		        .Run();
        }
    }
}
