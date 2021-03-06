﻿using System;
using Castle.Windsor;
using Feonufry.CUI.Actions;

namespace PunisherConsole
{
    public class WindsorActionFactory : IActionFactory
    {
        private readonly WindsorContainer _container;

        public WindsorActionFactory(WindsorContainer container)
        {
            _container = container;
        }

        public IAction Create(Type type)
        {
            return (IAction)_container.Resolve(type);
        }

        public void Release(IAction action)
        {
            _container.Release(action);
        }
    }
}