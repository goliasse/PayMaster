using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class TimepunchDBService : BaseDBService<Timepunches, int>
    {
        public TimepunchDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}