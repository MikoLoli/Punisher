using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using Punisher.API;
using Punisher.Domain;
using Punisher.Domain.Repositories;
using Punisher.NHibernate;

namespace Punisher.CastleWindsor
{
    public class NhCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(NhRepository<>)));
            container.Register(Component.For<NhConfigurator>());
            container.Register(Component.For<ISessionFactory>().UsingFactoryMethod(NhConfigurator.InitializeSessionFactory));
            container.Register(Component.For<NhInterceptor>());
            container.Register(Classes.FromThisAssembly().InSameNamespaceAs<ActionAPI>().Configure(c => c.Interceptors<NhInterceptor>()));
        }
    }
}
