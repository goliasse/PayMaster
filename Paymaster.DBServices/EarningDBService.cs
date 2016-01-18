using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EarningDBService : BaseDBService<Earnings, int>
    {
        public EarningDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}