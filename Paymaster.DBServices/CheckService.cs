using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class CheckService : BaseDBService<Checks, int>
    {
        public CheckService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}