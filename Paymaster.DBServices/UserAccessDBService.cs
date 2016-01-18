using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class UserAccessDBService : BaseDBService<Useraccess, int>
    {
        public UserAccessDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}