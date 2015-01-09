using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.API;
using Punisher.Domain;
using Punisher.Domain.RepositoryExtentions;

namespace PunisherConsole.Actions
{
    public class FindByNameAction : IAction
    {
        private readonly ActionAPI _actionApi;
        private readonly GetListOfResourcesApi _resourceApi;

        public FindByNameAction(ActionAPI actionApi, GetListOfResourcesApi resourceApi)
        {
            _actionApi = actionApi;
            _resourceApi = resourceApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО сотрудника: ");
            string employeeFio = Console.ReadLine();
            var employees = _resourceApi.GetEmployeeListByFio(employeeFio);
            //var employees = _actionApi._employeeRepository.FindByFio(employeeFio);
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
                //var employeeActions = _resourceApi._employeeActionRepository.FindActionByEmployeeFio(employeeFio);
                var employeeActions = _resourceApi.GetActionByEmployeeFio(employeeFio);
                var n = 1;
                foreach (var employeeActionsExample in employeeActions)
                {
                    Console.WriteLine(n + " " + employeeActionsExample.Type);
                    Console.WriteLine(employeeActionsExample.Date);
                    n++;
                }
            }
        }
    }
}
