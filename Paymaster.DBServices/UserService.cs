using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class UserService : BaseDBService<Users, int>
    {
        public UserService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}