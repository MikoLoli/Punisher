using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Punisher.Domain;
using Punisher.DTO;

namespace Punisher.API
{
    public class GetListOfResourcesApi
    {
        public readonly IRepository<Employee> _employeeRepository;
        public readonly IRepository<EmployeeAction> _employeeActionRepository;
        public readonly IRepository<ActionType> _actionTypesRepository;
        public readonly IRepository<MeasureType> _measureTypesRepository;
        public readonly IRepository<Measure> _measureRepository;

        public GetListOfResourcesApi(IRepository<Employee> employeeRepository, IRepository<EmployeeAction> employeeActionRepository, 
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

        //public virtual List<Employee> GetListByFio(string employeeFio)
        //{
            /*return _employeeRepository.FindByFio(employeeFio)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    FIO = x.FIO,
                    PersonnelNumber = x.PersonnelNumber,
                    RecruitmentDate = x.RecruitmentDate,
                    Reputation = x.Reputation,
                    Position = x.Position,
                    WageRate = x.WageRate,
                    Salary = x.Salary,
                    Action = x.a
                })
                .ToList();
             */
        //}

        /*public virtual List<VisitDto> GetVisitsByStatus(VisitStatus visitStatus)
        {
            return _visitsRepository.ForStatus(visitStatus)
                .Select(x => new VisitDto
                {
                    Id = x.Id,
                    CheckInDate = x.CheckInDate,
                    CheckOutDate = x.CheckOutDate,
                    Status = x.Status,
                    TotalCost = x.TotalCost,
                    ClientName = x.Client.FullName
                })
                .ToList();
        }
        */
    }
}
