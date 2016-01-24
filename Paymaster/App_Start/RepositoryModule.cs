using NHibernate;
using Ninject.Modules;
using Ninject.Web.Common;
using Paymaster.App_Start;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;
using System.Configuration;
using NHibernate.Context;
using Ninject;
using Ninject.Activation;

namespace Paymaster
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;

            NHibernateHelper helper = new NHibernateHelper(connectionString);

            Bind<ISessionFactory>().ToConstant(helper.SessionFactory)
                .InSingletonScope();

            //Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<ISession>().ToProvider(new SessionProvider(helper.SessionFactory)).InRequestScope();

            //Bind<SessionProvider>().ToSelf().Using<OnePerRequestBehavior>();

            //Bind<ISession>().ToMethod(CreateSession).InRequestScope();
            Bind<ITokenRepository>().To<TokenRepository>();
            Bind<IUserRepository>().To<UserRepository>();
        }

        //private ISession CreateSession(IContext context)
        //{

        //    var sessionFactory = context.Kernel.Get<ISessionFactory>();
        //    if (!CurrentSessionContext.HasBind(sessionFactory))
        //    {
        //        var session = sessionFactory.OpenSession();
        //        session.FlushMode = FlushMode.Never;
        //        CurrentSessionContext.Bind(session);
        //    }
        //    return sessionFactory.GetCurrentSession();
        //}
    }
}