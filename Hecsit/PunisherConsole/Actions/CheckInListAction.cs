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
            foreach (var employee in employees)
            {
                var employeeId = employee.Id;
                checkInListMenu.Item(string.Format("-*-{0}", employee.FIO), ctx => GetInformation(ctx, employeeId));
            }

            checkInListMenu.GetMenu().Run();
        }

	    private void GetInformation(ActionExecutionContext ctx, Guid employeeId)
	    {
            Console.Clear();
            var employee = _employeeRepository.Get(employeeId);
            Console.WriteLine("Сотрудник : " + employee.FIO);
            Console.WriteLine("Персональнаый номер : " + employee.PersonnelNumber);
            Console.WriteLine("Должность : " + employee.Position);
            Console.WriteLine("Дата принятия на работу : " + employee.RecruitmentDate);
            Console.WriteLine("Репутация : " + employee.Reputation);
            Console.WriteLine("Ставка : " + employee.WageRate);
            Console.WriteLine("Оклад : " + employee.Salary);

	    }
    }
}
