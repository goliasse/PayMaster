using NHibernate;
using Ninject;
using Ninject.Activation;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;

namespace Paymaster.App_Start
{
    public class SessionProvider : Provider<ISession>
    {
        protected override ISession CreateInstance(IContext context)
        {
            var unitOfWork = (UnitOfWork)context.Kernel.Get<IUnitOfWork>();
            return unitOfWork.Session;
        }
    }
}