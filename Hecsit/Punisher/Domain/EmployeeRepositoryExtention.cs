using System;
using Feonufry.CUI.Actions;
using System.Linq;

namespace Punisher.Domain
{
    public static class EmployeeRepositoryExtention
    {
        public static IQueryable<Employee> FindByFio(this IRepository<Employee> repository, String employeeFio)
        {
            return repository.AsQueryable().Where(x => x.FIO == employeeFio);
        }
    }
}
