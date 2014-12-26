using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
	public class EmployeeActionAddAction : IAction
	{
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

	    public EmployeeActionAddAction(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypesRepository, IRepository<MeasureType> measureTypesRepository, IRepository<Measure> measureRepository)
	    {
	        _employeeRepository = employeeRepository;
	        _employeeActionRepository = employeeActionRepository;
	        _actionTypesRepository = actionTypesRepository;
	        _measureTypesRepository = measureTypesRepository;
	        _measureRepository = measureRepository;
	    }

	    public void Perform(ActionExecutionContext context)
		{
			Console.Clear();
            Console.WriteLine("Выберите сотрудника для добавления действия.");
            var employees = _employeeRepository.AsQueryable().ToList();
	        int n = 1;
            foreach (var example in employees)
            {
                Console.WriteLine( n + example.FIO );
                n++;
            }
	        string empNum = Console.ReadLine();
	        switch (empNum)
	        {
                case '1':
	            {
                    employees = _employeeRepository.FindByFio(employeeFIO);
                    foreach (var employeeExample in employees)
                        Console.WriteLine("{0}", employeeExample);
	            }
	        }
		}
	}
}