
using System;
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
            Console.Clear();
	        new MenuBuilder()
		        .Title("Punisher v1.0")
		        .Prompt("Выберите действие")
                .Item("Просмотреть информацию о сотрудниках", new ViewEmployeeInformationAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
                .Item("Добавить действие", new EmployeeActionAddAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
                .Submenu("Применить поощрение")
                    .Item("Выписать благодарность", new GratitudeAssignAction())
                    .Item("Назначить премию", new AwardAssignAction())
                    .Item("Путевка", new VoyageAssignAction())
                    .Exit("Назад")
                    .End()
                .Submenu("Применить наказание")
                    .Item("Дисциплинарное взыскание", new ChastisementAssignAction())
                    .Item("Вычет из з/п", new CheckageAssignAction())
                    .Item("Увольние", new DismissalAction())
                    .Exit("Назад")
                    .End()
		        .Exit("Выход")
		        .GetMenu()
		        .Run();
        }
    }
}
