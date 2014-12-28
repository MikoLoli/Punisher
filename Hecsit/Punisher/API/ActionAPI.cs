using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punisher.Domain;

namespace Punisher.API
{
    public class ActionAPI
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<EmployeeAction> _employeeActionRepository;
        private readonly IRepository<ActionType> _actionTypesRepository;
        private readonly IRepository<MeasureType> _measureTypesRepository;
        private readonly IRepository<Measure> _measureRepository;

        public ActionAPI(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, 
            IRepository<ActionType> actionTypeRepository, IRepository<MeasureType> measureTypeRepository, 
            IRepository<Measure> measureRepository)
		{
            if (employeeRepository == null) throw new ArgumentNullException("employeeRepository");
            if (employeeActionRepository == null) throw new ArgumentNullException("employeeActionRepository");
            if (actionTypeRepository == null) throw new ArgumentNullException("actionTypeRepository");
            if (measureTypeRepository == null) throw new ArgumentNullException("measureTypeRepository");
            if (measureRepository == null) throw new ArgumentNullException("measureRepository");

            _employeeRepository = employeeRepository;
            _employeeActionRepository = employeeActionRepository;
            _actionTypesRepository = actionTypeRepository;
            _measureTypesRepository = measureTypeRepository;
            _measureRepository = measureRepository;
		}

        public void AddActionForEmployee(Employee employeeForAction, DateTime dateForAction,
            String descriptionForAction, ActionType actionTypeForAction)
        {
            EmployeeAction action = new EmployeeAction(employeeForAction,
               dateForAction,descriptionForAction, actionTypeForAction);
            employeeForAction.AddAction(action);
            _employeeActionRepository.Add(action);
        }
    }
}
