using System;
using System.Linq;
using Punisher.Domain;

namespace Punisher.TestData
{
	public class TestDataGenerator
	{
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

	    public TestDataGenerator(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypesRepository, IRepository<MeasureType> measureTypesRepository, IRepository<Measure> measureRepository)
	    {
	        _employeeRepository = employeeRepository;
	        _employeeActionRepository = employeeActionRepository;
	        _actionTypesRepository = actionTypesRepository;
	        _measureTypesRepository = measureTypesRepository;
	        _measureRepository = measureRepository;
	    }

	    public void Generate()
		{
            _measureTypesRepository.Add(new MeasureType("Прощение грехов", MeasureKind.Bonus, 0));
            _measureTypesRepository.Add(new MeasureType("Выговор", MeasureKind.Penalty, 1));
            _measureTypesRepository.Add(new MeasureType("Дисциплинарное взыскание", MeasureKind.Penalty, 2));
			_measureTypesRepository.Add(new MeasureType("Вычет из заработной платы", MeasureKind.Penalty, 3));
			_measureTypesRepository.Add(new MeasureType("Увольнение", MeasureKind.Penalty, 4));
            _measureTypesRepository.Add(new MeasureType("Благодарность", MeasureKind.Bonus, 1));
            _measureTypesRepository.Add(new MeasureType("Премия", MeasureKind.Bonus, 2));
            _measureTypesRepository.Add(new MeasureType("Путевка", MeasureKind.Bonus, 3));


            _actionTypesRepository.Add(new ActionType("Прогул до 4х часов",
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(0),
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(1)));
            _actionTypesRepository.Add(new ActionType("Прогул от 4х часов до дня",
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(1),
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(2)));
            _actionTypesRepository.Add(new ActionType("Повреждение имущества",
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(2),
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(3)));
            _actionTypesRepository.Add(new ActionType("Хищение/уничтожение имущества",
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(3),
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(4)));
            _actionTypesRepository.Add(new ActionType("Переработка",
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(5),
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(6)));
            _actionTypesRepository.Add(new ActionType("Творческое задание",
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(6),
                _measureTypesRepository.AsQueryable().ElementAt<MeasureType>(7)));


            _employeeRepository.Add(new Employee("Nolan Ross", "001", DateTime.Parse("2/16/2008 11:15:12 AM"),
                 3, "DG", 1.0m, 1000000.0m));
            _employeeRepository.Add(new Employee("Aiden Mathis", "002", DateTime.Parse("10/25/2010 11:04:53 AM"),
                1, "Financial analyst", 1.0m, 50000.0m));
            _employeeRepository.Add(new Employee("Mason Treadwell", "003", DateTime.Parse("7/7/2011 09:20:13 AM"),
                0, "Redactor", 1.0m, 40000.0m));
            _employeeRepository.Add(new Employee("David Clarke", "004", DateTime.Parse("3/14/2009 1:40:28 PM"),
                2, "Team leader", 1.0m, 80000.0m));
            _employeeRepository.Add(new Employee("Padma Lahare", "005", DateTime.Parse("8/5/2014 09:57:23 AM"),
                1, "Junior developer", 0.5m, 30000.0m));
            _employeeRepository.Add(new Employee("Margaux LeMarchal", "006", DateTime.Parse("3/14/2012 10:05:48 AM"),
                1, "PR manager", 1.0m, 50000.0m));

            _employeeActionRepository.Add(new EmployeeAction(_employeeRepository.AsQueryable().ElementAt<Employee>(2),
                DateTime.Now.Subtract(TimeSpan.FromDays(2)),
                "None",
                _actionTypesRepository.AsQueryable().ElementAt<ActionType>(0)));
            
		}
	}
}