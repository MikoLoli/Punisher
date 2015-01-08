using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using Punisher.NHibernate.Mappings;

namespace Punisher.NHibernate
{
    public class NhConfigurator
    {
        private static ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISessionFactory InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.FromConnectionStringWithKey("PunisherConsole.Properties.Settings.PunisherDataBaseConnectionString")))
                //.ConnectionString(c => c.FromConnectionStringWithKey("HotelBooking.ConsoleUI.Properties.Settings.HotelBookingDataBaseConnectionString")))
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .CurrentSessionContext<ThreadStaticSessionContext>()
                .BuildSessionFactory();
            return _sessionFactory;
        }

        public static ISessionFactory RecreateDb()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.FromConnectionStringWithKey("PunisherConsole.Properties.Settings.PunisherDataBaseConnectionString")))
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                .CurrentSessionContext<ThreadStaticSessionContext>()
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                .BuildSessionFactory();
            return _sessionFactory;
        }

        public static ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
