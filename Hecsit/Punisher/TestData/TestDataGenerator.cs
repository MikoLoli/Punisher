using System;
using System.Linq;
using Punisher.API;
using Punisher.Domain;
using Punisher.Domain.RepositoryExtentions;

namespace Punisher.TestData
{
	public class TestDataGenerator
	{
        private readonly ActionAPI _actionApi;

        public TestDataGenerator(ActionAPI actionApi)
	    {
            _actionApi = actionApi;
	    }
        public TestDataGenerator()
        { }

	    public virtual void Generate()
		{
            _actionApi._measureTypesRepository.Add(new MeasureType("Прощение грехов", MeasureKind.Bonus, 0));
            _actionApi._measureTypesRepository.Add(new MeasureType("Выговор", MeasureKind.Penalty, 1));
            _actionApi._measureTypesRepository.Add(new MeasureType("Дисциплинарное взыскание", MeasureKind.Penalty, 2));
            _actionApi._measureTypesRepository.Add(new MeasureType("Вычет из заработной платы", MeasureKind.Penalty, 3));
            _actionApi._measureTypesRepository.Add(new MeasureType("Увольнение", MeasureKind.Penalty, 4));
            _actionApi._measureTypesRepository.Add(new MeasureType("Благодарность", MeasureKind.Bonus, 1));
            _actionApi._measureTypesRepository.Add(new MeasureType("Премия", MeasureKind.Bonus, 2));
            _actionApi._measureTypesRepository.Add(new MeasureType("Путевка", MeasureKind.Bonus, 3));


            _actionApi._actionTypesRepository.Add(new ActionType("Прогул до 4х часов",
                _actionApi._measureTypesRepository.FindByName("Прощение грехов"),
                _actionApi._measureTypesRepository.FindByName("Выговор")));
            _actionApi._actionTypesRepository.Add(new ActionType("Прогул от 4х часов до дня",
                _actionApi._measureTypesRepository.FindByName("Выговор"),
                _actionApi._measureTypesRepository.FindByName("Дисциплинарное взыскание")));
            _actionApi._actionTypesRepository.Add(new ActionType("Повреждение имущества",
                _actionApi._measureTypesRepository.FindByName("Дисциплинарное взыскание"),
                _actionApi._measureTypesRepository.FindByName("Вычет из заработной платы")));
            _actionApi._actionTypesRepository.Add(new ActionType("Хищение/уничтожение имущества",
                _actionApi._measureTypesRepository.FindByName("Вычет из заработной платы"),
                _actionApi._measureTypesRepository.FindByName("Увольнение")));
            _actionApi._actionTypesRepository.Add(new ActionType("Переработка",
                _actionApi._measureTypesRepository.FindByName("Благодарность"),
                _actionApi._measureTypesRepository.FindByName("Премия")));
            _actionApi._actionTypesRepository.Add(new ActionType("Творческое задание",
                _actionApi._measureTypesRepository.FindByName("Премия"),
                _actionApi._measureTypesRepository.FindByName("Путевка")));


            _actionApi._employeeRepository.Add(new Employee("Nolan Ross", "001", DateTime.Parse("2/16/2008 11:15:12 AM", System.Globalization.CultureInfo.InvariantCulture),
                 3, "DG", 1.0m, 1000000.0m));
            _actionApi._employeeRepository.Add(new Employee("Aiden Mathis", "002", DateTime.Parse("10/25/2010 11:04:53 AM", System.Globalization.CultureInfo.InvariantCulture),
                1, "Financial analyst", 1.0m, 50000.0m));
            _actionApi._employeeRepository.Add(new Employee("Mason Treadwell", "003", DateTime.Parse("7/7/2011 09:20:13 AM", System.Globalization.CultureInfo.InvariantCulture),
                0, "Redactor", 1.0m, 40000.0m));
            _actionApi._employeeRepository.Add(new Employee("David Clarke", "004", DateTime.Parse("3/14/2009 1:40:28 PM", System.Globalization.CultureInfo.InvariantCulture),
                2, "Team leader", 1.0m, 80000.0m));
            _actionApi._employeeRepository.Add(new Employee("Padma Lahare", "005", DateTime.Parse("8/5/2014 09:57:23 AM", System.Globalization.CultureInfo.InvariantCulture),
                1, "Junior developer", 0.5m, 30000.0m));
            _actionApi._employeeRepository.Add(new Employee("Margaux LeMarchal", "006", DateTime.Parse("3/14/2012 10:05:48 AM", System.Globalization.CultureInfo.InvariantCulture),
                1, "PR manager", 1.0m, 50000.0m));

            _actionApi._employeeActionRepository.Add(new EmployeeAction(_actionApi._employeeRepository.FindByFio("Mason Treadwell")[0],
                DateTime.Now.Subtract(TimeSpan.FromDays(2)),
                "None",
                _actionApi._actionTypesRepository.AsQueryable().FirstOrDefault(x => x.Name.Equals("Прогул до 4х часов"))));
               // _actionApi._actionTypesRepository.FindByName("Прогул до 4х часов")));
            _actionApi._employeeActionRepository.Add(new EmployeeAction(_actionApi._employeeRepository.FindByFio("Nolan Ross")[0],
                DateTime.Now.Subtract(TimeSpan.FromDays(17)),
                "He's so cute",
                _actionApi._actionTypesRepository.AsQueryable().FirstOrDefault(x => x.Name.Equals("Переработка"))));
		}
	}
}