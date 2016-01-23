using NHibernate;
using Ninject.Modules;
using Ninject.Web.Common;
using Paymaster.App_Start;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;
using System.Configuration;

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

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<ISession>().ToProvider(new SessionProvider()).InRequestScope();
            Bind<ITokenRepository>().To<TokenRepository>();
            Bind<IUserRepository>().To<UserRepository>();
        }
    }
}