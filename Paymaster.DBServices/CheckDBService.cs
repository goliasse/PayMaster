using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class CheckDBService : BaseDBService<Checks, int>
    {
        public CheckDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}