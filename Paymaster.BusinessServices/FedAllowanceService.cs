using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class FedAllowanceService : Repository<FedAllowance>, IFedAllowanceService
    {
        public FedAllowanceService(ISession session) : base(session)
        {
        }
    }
}