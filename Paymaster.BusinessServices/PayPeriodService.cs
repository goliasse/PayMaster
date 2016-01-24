using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class PayPeriodService : Repository<PayPeriod>, IPayPeriodService
    {
        public PayPeriodService(ISession session) : base(session)
        {
        }
    }
}