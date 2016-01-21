using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EarningService : BaseDBService<Earnings, int>
    {
        public EarningService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}