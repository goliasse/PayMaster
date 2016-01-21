using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class FedTaxTablesService : BaseDBService<Fedtaxtables, int>
    {
        public FedTaxTablesService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}