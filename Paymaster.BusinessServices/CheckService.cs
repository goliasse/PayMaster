using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class CheckService : Repository<Check>, ICheckService
    {
        public CheckService(ISession session) : base(session)
        {
        }
    }
}