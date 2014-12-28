using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class ShowAllAction : IAction
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

        public ShowAllAction(IRepository<Employee> employeeRepository,
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
            var employeeActions = _employeeActionRepository.AsQueryable().ToList();
            var n = 1;
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
