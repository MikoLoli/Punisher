using System;
using System.Collections.Generic;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.API;
using Punisher.Domain;

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

        public AddActionForEmployeeAction(ActionAPI actionApi, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypesRepository, IRepository<MeasureType> measureTypesRepository, IRepository<Measure> measureRepository)
        {
            _actionApi = actionApi;
	        _employeeRepository = _actionApi._employeeRepository;
	        _employeeActionRepository = employeeActionRepository;
	        _actionTypesRepository = actionTypesRepository;
	        _measureTypesRepository = measureTypesRepository;
	        _measureRepository = measureRepository;
	    }

	    public void Perform(ActionExecutionContext context)
		{
			Console.Clear();
            Console.WriteLine("Выберите сотрудника для добавления действия.");
            //var employees = _employeeRepository.AsQueryable().ToList();
            //   |   |
            //   |   |
            //  \     /
            //   \   /
            //    \ /
	        var employees = _employeeRepository.AsQueryable().ToList();
            var employeeCheckMenu = new MenuBuilder()
                .RunnableOnce()
                .Title("Список сотрудников");
	        Guid selectedEmployeeId = employees[0].Id;
            foreach (var employeeExample in employees)
            {
                employeeCheckMenu.Item(string.Format("-*-{0}", employeeExample.FIO), ctx => selectedEmployeeId = employeeExample.Id);
            }
            employeeCheckMenu.GetMenu().Run();

            Console.Clear();
            var actionTypes = _actionTypesRepository.AsQueryable().ToList();
            var actionTypeCheckMenu = new MenuBuilder()
                .RunnableOnce()
                .Title("Выберите тип деяния.");
	        Guid selectedActionId = actionTypes[0].Id;
            foreach (var actTypeExample in actionTypes)
            {
                actionTypeCheckMenu.Item(string.Format("-*-{0}", actTypeExample.Name), ctx => selectedActionId = actTypeExample.Id);
            }
            actionTypeCheckMenu.GetMenu().Run();

            Console.Clear();
            Console.WriteLine("Введите дату деяния в формате mm/dd/yy hour:min:sec AM.");
	        string actTime = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Введите комментарий/описание деяния.");
	        string actDescription = Console.ReadLine();
            
            _actionApi.AddActionForEmployee(selectedEmployeeId, DateTime.Parse(actTime, System.Globalization.CultureInfo.InvariantCulture),
                actDescription, selectedActionId);


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
	}
}