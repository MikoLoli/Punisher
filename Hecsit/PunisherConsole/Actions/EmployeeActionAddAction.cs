using System;
using System.Collections.Generic;
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
            foreach (var employeeExample in employees)
            {
                Console.WriteLine( n + " " + employeeExample.FIO );
                n++;
            }
	        string empFio = Console.ReadLine();
            Console.Clear();
	        Console.WriteLine("Выберите тип деяния.");
            var actionTypes = _actionTypesRepository.AsQueryable().ToList();
            n = 1;
            foreach (var actionTypesExample in actionTypes)
            {
                Console.WriteLine(n + " " + actionTypesExample.Name);
                n++;
            }
            string actType = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите дату деяния в формате mm/dd/yy hour:min:sec AM.");
	        string actTime = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите комментарий/описание деяния.");
	        string actDescription = Console.ReadLine();
	        List<Employee> employeeForAction = _employeeRepository.FindByFio(empFio);
	        List<ActionType> actionTypeForAction = _actionTypesRepository.FindByName(actType);
            EmployeeAction action = new EmployeeAction(employeeForAction[0], 
                DateTime.Parse(actTime, System.Globalization.CultureInfo.InvariantCulture),
                actDescription, actionTypeForAction[0]);
            employeeForAction[0].AddAction(action);
            _employeeActionRepository.Add(action);
            var employeeActions = _employeeActionRepository.AsQueryable().ToList();
            n = 1;
            Console.Clear();
            foreach (var employeeActionsExample in employeeActions)
            {
                Console.WriteLine(n + " " + employeeActionsExample.Employee.FIO);
                Console.WriteLine(employeeActionsExample.Type.Name);
                Console.WriteLine(employeeActionsExample.Date);
                n++;
            }
		}
	}
}