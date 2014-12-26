using System;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
	public class ViewEmployeeInformationAction : IAction
	{
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

	    public ViewEmployeeInformationAction(IRepository<Employee> employeeRepository,
            IRepository<EmployeeAction> employeeActionRepository, 
            IRepository<ActionType> actionTypesRepository, 
            IRepository<MeasureType> measureTypesRepository, 
            IRepository<Measure> measureRepository)
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
	        var menu = new MenuBuilder()
	            .RunnableOnce()
                .Item("Выбрать из списка", new CheckInListAction(_employeeRepository, _employeeActionRepository, _actionTypesRepository, _measureTypesRepository, _measureRepository))
                .Item("Выбрать по ФИО", new FindByNameAction(_employeeRepository, _employeeActionRepository, _actionTypesRepository, _measureTypesRepository, _measureRepository))
	            .Exit("Назад");
            menu.GetMenu().Run();
            //context.Out.WriteLine(ConsoleColor.Green, "Типы мер");
			//var measureTypes = _measureTypesRepository.AsQueryable().ToList();
			//foreach (var type in measureTypes)
			//{
			//	context.Out.WriteLine(type.Name);
			//}
		}
	}
}