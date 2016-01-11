using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PayorService : BaseDBService<Payors, int>
    {
        private readonly ISessionFactory _sessionFactory;

        public PayorService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}