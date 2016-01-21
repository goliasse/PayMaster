using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PayPeriodService : BaseDBService<Payperiods, int>
    {
        public PayPeriodService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}