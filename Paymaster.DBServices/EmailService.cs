using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EmailService : BaseDBService<Emails, int>
    {
        public EmailService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}