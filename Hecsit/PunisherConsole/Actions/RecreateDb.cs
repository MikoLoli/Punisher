using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feonufry.CUI.Actions;
using Punisher.NHibernate;
using Punisher.TestData;

namespace PunisherConsole.Actions
{
    public class RecreateDb : IAction
    {
        private readonly TestDataGenerator _dataGenerator;

        public RecreateDb(TestDataGenerator dataGenerator)
        {
            _dataGenerator = dataGenerator;
        }

        public void Perform(ActionExecutionContext context)
        {
            Console.WriteLine("Processing...\n");
            NhConfigurator.RecreateDb();
            _dataGenerator.Generate();
        }
    }
}
