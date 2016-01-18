using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PayPeriodDBService : BaseDBService<Payperiods, int>
    {
        public PayPeriodDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}