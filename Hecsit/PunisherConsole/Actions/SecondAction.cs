using System;
using Feonufry.CUI.Actions;

namespace PunisherConsole.Actions
{
	public class SecondAction : IAction
	{
		public void Perform(ActionExecutionContext context)
		{
			context.Out.Write(ConsoleColor.Green, "SECOND");
		}
	}
}