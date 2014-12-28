
using System;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;
using Punisher.TestData;
using PunisherConsole.Actions;
using PunisherConsole.API;

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
            var actionApi = new ActionAPI(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep);
	        var generator = new TestDataGenerator(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep);
			generator.Generate();
            Console.Clear();
	        new MenuBuilder()
		        .Title("Punisher v1.0")
		        .Prompt("Выберите действие")
                .Submenu("Просмотреть информацию о сотрудниках")
                    .Item("Выбрать из списка", new CheckInListAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
                    .Item("Выбрать по ФИО", new FindByNameAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
                    .Exit("Назад")
                    .End()
                .Item("Добавить действие", new AddActionForEmployeeAction(actionApi, employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
                .Submenu("Применить поощрение")
                    .Item("Выписать благодарность", new GratitudeAssignAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
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
                .Item("Показать все действия", new ShowAllAction(employeeRep, employeeActionRep, actionTypeRep, measureTypeRep, measureRep))
		        .Exit("Выход")
		        .GetMenu()
		        .Run();
        }
    }
}
