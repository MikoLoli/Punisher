using System;
using Feonufry.CUI.Actions;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class GratitudeAssignAction : IAction
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;
        public GratitudeAssignAction(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, IRepository<ActionType> actionTypesRepository, IRepository<MeasureType> measureTypesRepository, IRepository<Measure> measureRepository)
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
            Console.WriteLine("Введите диапазон дат для поиска плюсов у сотрудников : ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            DateTime d;
           // for (d = startDate; d.Date != endDate.Date; d.Date.AddDays(1))
            //{
             //   _employeeRepository.
            //}
        }
    }
}
