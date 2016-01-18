using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class FedTaxTablesDBService : BaseDBService<Fedtaxtables, int>
    {
        public FedTaxTablesDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}