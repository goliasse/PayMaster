using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Context;

namespace PayMaster.DataAccess
{
    public static class SessionExtensions
    {
        public static bool IsActive(this ISession session)
        {
            return session.IsOpen && session.Transaction.IsActive;
        }

        public static ITransaction GetTransaction(this ISession session, ISessionFactory sessionFactory)
        {
            if (session == null || !session.IsOpen)
            {
                //var sessionFactory = WebContainerManager.Get<ISessionFactory>();
                session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            }

            return !session.Transaction.IsActive ? session.BeginTransaction() : session.Transaction;
        }
    }
}
