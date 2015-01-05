using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.API;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class FindByNameAction : IAction
    {
        private readonly ActionAPI _actionApi;

        public FindByNameAction(ActionAPI actionApi)
        {
            _actionApi = actionApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.Clear();
            Console.WriteLine("Введите ФИО сотрудника: ");
            string employeeFio = Console.ReadLine();
            var employees = _actionApi._employeeRepository.FindByFio(employeeFio);
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
                var employeeActions = _actionApi._employeeActionRepository.AsQueryable().Where(x => x.Employee.Id == employeeExample.Id).ToList();
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
