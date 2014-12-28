using System;
using System.Collections.Generic;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;
using PunisherConsole.API;

namespace PunisherConsole.Actions
{
	public class AddActionForEmployeeAction : IAction
	{
        private readonly ActionAPI _actionApi;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

        public AddActionForEmployeeAction(ActionAPI actionApi, IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypesRepository, IRepository<MeasureType> measureTypesRepository, IRepository<Measure> measureRepository)
        {
            _actionApi = actionApi;
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
            var EmployeeCheckMenu = new MenuBuilder()
                .RunnableOnce()
                .Title("Список сотрудников");
            Employee selectedEmployee = new Employee();
            foreach (var employeeExample in employees)
            {
                var employeeId = employeeExample.Id;
                EmployeeCheckMenu.Item(string.Format("-*-{0}", employeeExample.FIO), ctx => selectedEmployee = _employeeRepository.Get(employeeId));
            }
            EmployeeCheckMenu.GetMenu().Run();

            Console.Clear();
            var actionTypes = _actionTypesRepository.AsQueryable().ToList();
            var ActionTypeCheckMenu = new MenuBuilder()
                .RunnableOnce()
                .Title("Выберите тип деяния.");
	        ActionType selectedAction = new ActionType();
            foreach (var actTypeExample in actionTypes)
            {
                var actionTypeId = actTypeExample.Id;
                ActionTypeCheckMenu.Item(string.Format("-*-{0}", actTypeExample), ctx => selectedAction = _actionTypesRepository.Get(actionTypeId));
            }
            ActionTypeCheckMenu.GetMenu().Run();

            Console.Clear();
            Console.WriteLine("Введите дату деяния в формате mm/dd/yy hour:min:sec AM.");
	        string actTime = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Введите комментарий/описание деяния.");
	        string actDescription = Console.ReadLine();
            
            _actionApi.AddActionForEmployee(selectedEmployee, DateTime.Parse(actTime, System.Globalization.CultureInfo.InvariantCulture),
                actDescription, selectedAction);


	        /*List<Employee> employeeForAction = _employeeRepository.FindByFio(empFio);
	        List<ActionType> actionTypeForAction = _actionTypesRepository.FindByName(actType);
            EmployeeAction action = new EmployeeAction(employeeForAction[0], 
                DateTime.Parse(actTime, System.Globalization.CultureInfo.InvariantCulture),
                actDescription, actionTypeForAction[0]);
            employeeForAction[0].AddAction(action);
            _employeeActionRepository.Add(action);
            var employeeActions = _employeeActionRepository.AsQueryable().ToList();
            n = 1;
             * 
             * 
             * 
            Console.Clear();
            foreach (var employeeActionsExample in employeeActions)
            {
                Console.WriteLine(n + " " + employeeActionsExample.Employee.FIO);
                Console.WriteLine(employeeActionsExample.Type.Name);
                Console.WriteLine(employeeActionsExample.Date);
                n++;
            }*/

            

		}

        private Employee GetEmployeeById(ActionExecutionContext ctx, Guid employeeId)
        {
            Console.Clear();
            return _employeeRepository.Get(employeeId);

        }

        private void GetActionTypeById(ActionExecutionContext ctx, Guid actTypeId)
        {
            Console.Clear();
            var employee = _actionTypesRepository.Get(actTypeId);

        }
	}
}