using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PayorVariableService : BaseDBService<Payorvariables, int>
    {
        public PayorVariableService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}