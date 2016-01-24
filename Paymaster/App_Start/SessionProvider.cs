using System;
using NHibernate;
using Ninject;
using Ninject.Activation;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;
using NHibernate.Context;

namespace Paymaster.App_Start
{
    public class SessionProvider : Provider<ISession>
    {
        ISessionFactory _sessionFactory;
        public SessionProvider(ISessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        protected override ISession CreateInstance(IContext context)
        {
            //var unitOfWork = (UnitOfWork)context.Kernel.Get<IUnitOfWork>();
            //return unitOfWork.Session;
            var session = _sessionFactory.OpenSession();
            //WebSessionContext.Bind(session);
            return session;
        }
    }

    //    public class SessionProvider : Provider<ISession>, IDisposable
    //    {
    //        ISessionFactory _sessionFactory;
    //        ISession session;

    //        public SessionProvider(ISessionFactory sessionFactory)
    //        {
    //            this._sessionFactory = sessionFactory;
    //        }

    //        protected override ISession CreateInstance(IContext context)
    //        {
    //            var session = _sessionFactory.OpenSession();
    //            WebSessionContext.Bind(session);
    //            return session;
    //        }

    //        public ISession GetCurrentSession()
    //        {
    //            var factory = _sessionFactory; // GetFactory returns an ISessionFactory in my helper class
    //            ISession session;
    //            if (WebSessionContext.HasBind(factory))
    //            {
    //                session = factory.GetCurrentSession();
    //            }
    //            else
    //            {
    //                session = factory.OpenSession();
    //                CurrentSessionContext.Bind(session);
    //            }
    //            return session;
    //        }

    //        public void EndContextSession()
    //        {
    //            var factory = _sessionFactory;
    //            var session = CurrentSessionContext.Unbind(factory);
    //            if (session != null && session.IsOpen)
    //            {
    //                try
    //                {
    //                    if (session.Transaction != null && session.Transaction.IsActive)
    //                    {
    //                        session.Transaction.Rollback();
    //                        throw new Exception("Rolling back uncommited NHibernate transaction.");
    //                    }
    //                    session.Flush();
    //                }
    //                catch (Exception ex)
    //                {
    //                    //log.Error("SessionKey.EndContextSession", ex);
    //                    throw;
    //                }
    //                finally
    //                {
    //                    session.Close();
    //                    session.Dispose();
    //                }
    //            }
    //        }

    //        public void Dispose()
    //        {
    //            if (session != null)
    //            {
    //                session.Dispose();
    //            }
    //        }
    //    }
}