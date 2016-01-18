using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EmailDBService : BaseDBService<Emails, int>
    {
        public EmailDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}