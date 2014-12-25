using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;

namespace Punisher.Domain
{
    public class ViewEmployeeInfoAction : IAction
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;
        private readonly String employeeFIO;
        public ViewEmployeeInfoAction(String fio,
            IRepository<Employee> employeeRepository,
            IRepository<EmployeeAction> employeeActionRepository,
            IRepository<ActionType> actionTypesRepository,
            IRepository<MeasureType> measureTypesRepository,
            IRepository<Measure> measureRepository)
        {
            employeeFIO = fio;
            _employeeRepository = employeeRepository;
            _employeeActionRepository = employeeActionRepository;
            _actionTypesRepository = actionTypesRepository;
            _measureTypesRepository = measureTypesRepository;
            _measureRepository = measureRepository;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.Clear();
            //var employee = _employeeRepository.fi
            foreach (var example in _employeeRepository)
                Console.WriteLine(example.FIO);
            //context.Out.WriteLine(_employeeRepository.AsQueryable().ElementAt<Employee>());
        }
    }
}
