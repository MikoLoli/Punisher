using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using NHibernate;
using NHibernate.Context;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

namespace Punisher.NHibernate
{
    public class NhInterceptor : IInterceptor
    {
        private readonly ISessionFactory _sessionFactory;

        public NhInterceptor(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Intercept(IInvocation invocation)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    CurrentSessionContext.Bind(session);
                    try
                    {
                        invocation.Proceed();
                        tx.Commit();
                    }
                    finally
                    {
                        CurrentSessionContext.Unbind(_sessionFactory);
                    }
                }
            }
        }
    }
}
