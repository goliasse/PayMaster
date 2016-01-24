using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class FedTaxTableService : Repository<FedTaxTable>, IFedTaxTableService
    {
        public FedTaxTableService(ISession session) : base(session)
        {
        }
    }
}