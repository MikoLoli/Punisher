using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Utils;
using Punisher.Domain;
using Punisher.Domain.RepositoryExtentions;
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

        public virtual EmployeeDto GetEmployeeById(Guid employeeId)
        {
            var employee = _employeeRepository.FindById(employeeId);
            var employeeDto = new EmployeeDto();
            employeeDto.Id = employee.Id;
            employeeDto.FIO = employee.FIO;
            employeeDto.PersonnelNumber = employee.PersonnelNumber;
            employeeDto.RecruitmentDate = employee.RecruitmentDate;
            employeeDto.Reputation = employee.Reputation;
            employeeDto.Position = employee.Position;
            employeeDto.WageRate = employee.WageRate;
            employeeDto.Salary = employee.Salary;
            return employeeDto;
        }
        public virtual List<EmployeeDto> GetEmployeeListByFio(string employeeFio)
        {
            return _employeeRepository.FindByFio(employeeFio)
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    FIO = x.FIO,
                    PersonnelNumber = x.PersonnelNumber,
                    RecruitmentDate = x.RecruitmentDate,
                    Position = x.Position,
                    Reputation = x.Reputation,
                    WageRate = x.WageRate,
                    Salary = x.Salary,
                }).ToList();
        }
        public virtual List<EmployeeActionDto> GetActionByEmployeeFio(string employeeFio)
        {
            return _employeeActionRepository.FindActionByEmployeeFio(employeeFio)
                .Select(x => new EmployeeActionDto
                {
                    Id = x.Id,
                    Type = x.Type.Name,
                    Date = x.Date,
                    Description = x.Description
                }).ToList();
        }
        
    }
}
