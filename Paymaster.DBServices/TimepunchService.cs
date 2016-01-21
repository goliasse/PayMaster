using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class TimepunchService : BaseDBService<Timepunches, int>
    {
        public TimepunchService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}