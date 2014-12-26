using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class CheckInListAction : IAction
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

        public CheckInListAction(IRepository<Employee> employeeRepository,
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
            var employees = _employeeRepository.AsQueryable().ToList();
            var checkInListMenu = new MenuBuilder()
                .RunnableOnce()
                .Title("Список сотрудников");
            foreach (var example in employees)
            {
                //var entityId = entity.Id;
                checkInListMenu.Item(string.Format("-*-{0}", example.FIO), new ViewEmployeeInfoAction(example.FIO,
                    _employeeRepository, _employeeActionRepository, _actionTypesRepository, _measureTypesRepository, _measureRepository));
            }
            checkInListMenu.GetMenu().Run();
        }
    }
}
