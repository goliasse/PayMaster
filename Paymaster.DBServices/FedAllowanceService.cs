using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public  class FedAllowanceService : BaseDBService<Fedallowances, int>
    {
        public FedAllowanceService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}