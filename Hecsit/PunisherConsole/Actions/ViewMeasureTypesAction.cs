using System;
using System.Linq;
using Feonufry.CUI.Actions;
using Punisher.Domain;

namespace PunisherConsole.Actions
{
	public class ViewMeasureTypesAction : IAction
	{
		private readonly IRepository<MeasureType> _measureTypesRepository;

		public ViewMeasureTypesAction(IRepository<MeasureType> measureTypesRepository)
		{
			_measureTypesRepository = measureTypesRepository;
		}

		public void Perform(ActionExecutionContext context)
		{
			context.Out.WriteLine(ConsoleColor.Green, "Типы мер");
			var measureTypes = _measureTypesRepository.AsQueryable().ToList();
			foreach (var type in measureTypes)
			{
				context.Out.WriteLine(type.Name);
			}
		}
	}
}