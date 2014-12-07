using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
	public class ViewMeasureTypesAction : IAction
	{
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

	    public ViewMeasureTypesAction(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypesRepository, IRepository<MeasureType> measureTypesRepository, IRepository<Measure> measureRepository)
	    {
	        _employeeRepository = employeeRepository;
	        _employeeActionRepository = employeeActionRepository;
	        _actionTypesRepository = actionTypesRepository;
	        _measureTypesRepository = measureTypesRepository;
	        _measureRepository = measureRepository;
	    }

	    public void Perform(ActionExecutionContext context)
		{
			context.Out.WriteLine(ConsoleColor.Green, "Типы мер");
			var measureTypes = _measureTypesRepository.AsQueryable().ToList();
			foreach (var type in measureTypes)
			{
				context.Out.WriteLine(type.Name);
			}
		}
	}
}