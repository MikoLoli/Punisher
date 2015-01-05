using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.API;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class CheckInListAction : IAction
    {
        private readonly ActionAPI _actionApi;

        public CheckInListAction(ActionAPI actionApi)
        {
            _actionApi = actionApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.Clear();
            var employees = _actionApi._employeeRepository.AsQueryable().ToList();
            var checkInListMenu = new MenuBuilder()
                .RunnableOnce()
                .Title("Список сотрудников");
            foreach (var employee in employees)
            {
                var employeeId = employee.Id;
                checkInListMenu.Item(string.Format("-*-{0}", employee.FIO), ctx => GetInformation(ctx, employeeId));
            }

            checkInListMenu.GetMenu().Run();
        }

	    private void GetInformation(ActionExecutionContext ctx, Guid employeeId)
	    {
            Console.Clear();
            var employee = _actionApi._employeeRepository.Get(employeeId);
            Console.WriteLine("  Сотрудник : " + employee.FIO);
            Console.WriteLine("Персональнаый номер : " + employee.PersonnelNumber);
            Console.WriteLine("Должность : " + employee.Position);
            Console.WriteLine("Дата принятия на работу : " + employee.RecruitmentDate);
            Console.WriteLine("Репутация : " + employee.Reputation);
            Console.WriteLine("Ставка : " + employee.WageRate);
            Console.WriteLine("Оклад : " + employee.Salary);

            Console.WriteLine("\n  Деяния : ");
            var employeeActions = _actionApi._employeeActionRepository.AsQueryable().Where(x => x.Employee.Id == employeeId).ToList();
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
