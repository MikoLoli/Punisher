using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Punisher.Domain;
using Punisher.API;
using Punisher.TestData;

namespace Punisher.Api
{
   /* public class CoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(MemoryRepository<>)));
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<ActionAPI>());
            container.Register(Component.For<TestDataGenerator>());
        }
    }*/
}