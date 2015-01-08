using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using NHibernate;
using NHibernate.Linq;
using Punisher.API;

namespace Punisher.Domain.Repositories
{
    public class NhRepository<T> : IRepository<T> where T : Entity
    {
        private readonly ISessionFactory _sessionFactory;

        public NhRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        protected ISession Session
        {
            get { return _sessionFactory.GetCurrentSession(); }
        }

        public T Get(Guid id)
        {
            return Session.Get<T>(id);
        }

        public void Add(T entity)
        {
            Session.Save(entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return Session.Query<T>();
        }

    }
}
