using System;
using Castle.Windsor;
using Feonufry.CUI.Menu.Builders;
using Punisher.Api;
using Punisher.Domain;
using Punisher.TestData;
using PunisherConsole.Actions;
using Punisher.API;

namespace PunisherConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new CoreInstaller(), new UIInstaller());
            var generator = container.Resolve<TestDataGenerator>();
            generator.Generate();

            Console.Clear();
	        new MenuBuilder()
                .WithActionFactory(new WindsorActionFactory(container))
		        .Title("Punisher v1.0")
		        .Prompt("Выберите действие")
                .Submenu("Просмотреть информацию о сотрудниках")
                    .Item<CheckInListAction>("Выбрать из списка")
                    .Item<FindByNameAction>("Выбрать по ФИО")
                    .Exit("Назад")
                    .End()
                .Item<AddActionForEmployeeAction>("Добавить действие")
                .Submenu("Применить поощрение")
                    .Item<GratitudeAssignAction>("Выписать благодарность")
                    .Item<AwardAssignAction>("Назначить премию")
                    .Item<VoyageAssignAction>("Выдать путевку")
                    .Exit("Назад")
                    .End()
                .Submenu("Применить наказание")
                    .Item<ChastisementAssignAction>("Дисциплинарное взыскание")
                    .Item<CheckageAssignAction>("Вычет из з/п")
                    .Item<DismissalAction>("Увольние") 
                    .Exit("Назад")
                    .End()
               // .Item<ShowAllAction>("Показать все действия")
		        .Exit("Выход")
		        .GetMenu()
		        .Run();
        }
    }
}
