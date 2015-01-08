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
        public readonly IRepository<Employee> _employeeRepository;
        public readonly IRepository<EmployeeAction> _employeeActionRepository;
        public readonly IRepository<ActionType> _actionTypesRepository;
        public readonly IRepository<MeasureType> _measureTypesRepository;
        public readonly IRepository<Measure> _measureRepository;

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

        public virtual void AddActionForEmployee(Guid employeeForActionId, DateTime dateForAction,
            String descriptionForAction, Guid actionTypeForActionId)
        {
            var employeeForAction = _employeeRepository.Get(employeeForActionId);
            var actionTypeForAction = _actionTypesRepository.Get(actionTypeForActionId);
            EmployeeAction action = new EmployeeAction(employeeForAction,
               dateForAction,descriptionForAction, actionTypeForAction);
            employeeForAction.AddAction(action);
            _employeeActionRepository.Add(action);
        }
    }
}
