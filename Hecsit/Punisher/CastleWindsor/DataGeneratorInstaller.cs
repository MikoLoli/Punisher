using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Punisher.NHibernate;
using Punisher.TestData;

namespace Punisher.CastleWindsor
{
    public class DataGeneratorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<TestDataGenerator>().Interceptors<NhInterceptor>()); ;
        }
    }
}
