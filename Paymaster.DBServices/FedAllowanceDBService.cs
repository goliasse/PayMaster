using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public  class FedAllowanceDBService : BaseDBService<Fedallowances, int>
    {
        public FedAllowanceDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}