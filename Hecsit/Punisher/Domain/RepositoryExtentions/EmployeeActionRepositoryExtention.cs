using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punisher.Domain.RepositoryExtentions
{
    public static class EmployeeActionRepositoryExtention
    {
        public static List<EmployeeAction> FindActionByEmployeeFio(this IRepository<EmployeeAction> repository, string employeeFio)
        {
            return repository.AsQueryable().Where(x => x.Employee.FIO == employeeFio).ToList();
        }
    }
}
