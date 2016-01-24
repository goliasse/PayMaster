using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class PayorVariableService : Repository<PayorVariable>, IPayorVariableService
    {
        public PayorVariableService(ISession session) : base(session)
        {
        }
    }
}