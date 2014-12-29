using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class FindByNameAction : IAction
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

        public FindByNameAction(IRepository<Employee> employeeRepository,
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
            Console.WriteLine("Введите ФИО сотрудника: ");
            string employeeFio = Console.ReadLine();
            var employees = _employeeRepository.FindByFio(employeeFio);
            foreach (var employeeExample in employees)
            {
                Console.WriteLine("Сотрудник : " + employeeExample.FIO);
                Console.WriteLine("Персональнаый номер : " + employeeExample.PersonnelNumber);
                Console.WriteLine("Должность : " + employeeExample.Position);
                Console.WriteLine("Дата принятия на работу : " + employeeExample.RecruitmentDate);
                Console.WriteLine("Репутация : " + employeeExample.Reputation);
                Console.WriteLine("Ставка : " + employeeExample.WageRate);
                Console.WriteLine("Оклад : " + employeeExample.Salary);

                Console.WriteLine("\n  Деяния : ");
                var employeeActions = _employeeActionRepository.AsQueryable().Where(x => x.Employee.Id == employeeExample.Id).ToList();
                var n = 1;
                foreach (var employeeActionsExample in employeeActions)
                {
                    Console.WriteLine(n + " " + employeeActionsExample.Type.Name);
                    Console.WriteLine(employeeActionsExample.Date);
                    n++;
                }
            }
        }
    }
}
