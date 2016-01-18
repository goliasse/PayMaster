using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PayorVariableDBService : BaseDBService<Payorvariables, int>
    {
        public PayorVariableDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}