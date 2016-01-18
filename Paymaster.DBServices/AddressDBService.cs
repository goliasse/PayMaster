using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class AddressDBService : BaseDBService<Addresses, int>
    {
        public AddressDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}