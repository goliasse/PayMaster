using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class AddressService : Repository<Address>, IAddressService
    {
        public AddressService(ISession session) : base(session)
        {
        }
    }
}