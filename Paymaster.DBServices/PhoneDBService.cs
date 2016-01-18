using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PhoneDBService : BaseDBService<Phones, int>
    {
        public PhoneDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}