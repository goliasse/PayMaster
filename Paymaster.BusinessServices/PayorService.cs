using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class PayorService : Repository<Payor>, IPayorService
    {
        public PayorService(ISession session) : base(session)
        {
        }
    }
}