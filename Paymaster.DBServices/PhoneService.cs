using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PhoneService : BaseDBService<Phones, int>
    {
        public PhoneService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}