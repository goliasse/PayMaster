using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class TimepuncheDBService : BaseDBService<Timepunches, int>
    {
        public TimepuncheDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}