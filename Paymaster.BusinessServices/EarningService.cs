using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class EarningService : Repository<Earning>, IEarningService
    {
        public EarningService(ISession session) : base(session)
        {
        }
    }
}