using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Feonufry.CUI.Menu.Builders;
using Punisher.API;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class ShowAllAction : IAction
    {
        private readonly ActionAPI _actionApi;

        public ShowAllAction(ActionAPI actionApi)
        {
            _actionApi = actionApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.Clear();
            /*var employeeActions = _actionApi._employeeActionRepository.AsQueryable().ToList();
            var n = 1;
            foreach (var employeeActionsExample in employeeActions)
            {
                Console.WriteLine(n + " " + employeeActionsExample.Employee.FIO);
                Console.WriteLine(employeeActionsExample.Type.Name);
                Console.WriteLine(employeeActionsExample.Date);
                n++;
            }*/
            var n = 1;
            foreach (var employeeActionsExample in _actionApi.ShowAllActions())
            {
                Console.WriteLine(n + " " + employeeActionsExample.Employee);
                Console.WriteLine(employeeActionsExample.Type);
               // Console.WriteLine(employeeActionsExample.Date);
                n++;
            }
        }
    }
}
