using System;
using System.Collections.Generic;
using Feonufry.CUI.Actions;
using System.Linq;

namespace Punisher.Domain
{
    public static class EmployeeRepositoryExtention
    {
        public static List<Employee> FindByFio(this IRepository<Employee> repository, string employeeFio)
        {
            return repository.AsQueryable().Where(x => x.FIO == employeeFio).ToList();
        }

        //public static List<Employee> FindByTimeAndPlus(this IRepository<Employee> repository, DateTime employeeActionDate, EmployeeAction employeeAction)
        //{
         //   return repository.AsQueryable().Where(x => x.EmployeeActions.;
        //}
    }
}
