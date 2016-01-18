using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class UserDBService : BaseDBService<Users, int>
    {
        public UserDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}