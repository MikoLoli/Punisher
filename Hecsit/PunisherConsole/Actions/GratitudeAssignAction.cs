using System;
using Feonufry.CUI.Actions;
using Punisher.API;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
    public class GratitudeAssignAction : IAction
    {
        private readonly ActionAPI _actionApi;

        public GratitudeAssignAction(ActionAPI actionApi)
        {
            _actionApi = actionApi;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.Clear();
            Console.WriteLine("Введите диапазон дат для поиска плюсов у сотрудников : ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            DateTime endDate = DateTime.Parse(Console.ReadLine());
           // DateTime d;
           // for (d = startDate; d.Date != endDate.Date; d.Date.AddDays(1))
            //{
             //   _employeeRepository.
            //}
        }
    }
}
