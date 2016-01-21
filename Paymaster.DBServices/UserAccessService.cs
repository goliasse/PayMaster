using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class UserAccessService : BaseDBService<Useraccess, int>
    {
        public UserAccessService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}