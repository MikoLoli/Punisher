﻿using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Feonufry.CUI.Actions;
using Punisher.NHibernate;

namespace PunisherConsole
{
    public class UIInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IAction>().WithServiceSelf());
        }
    }
}