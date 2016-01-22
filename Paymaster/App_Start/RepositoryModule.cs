using NHibernate;
using Ninject.Modules;
using Ninject.Web.Common;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;
using System.Configuration;
using Paymaster.BusinessServices;
using Paymaster.BusinessServices.Interfaces;

//using System.Data.Services;

namespace Paymaster.App_Start
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
            //Bind<IIntKeyedRepository<Payors>>().To<Repository<Payors>>();
            Bind<IPayorService>().To<PayorService>();
        }
    }
}