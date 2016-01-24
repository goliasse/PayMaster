using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class PhoneService : Repository<Phone>, IPhoneService
    {
        public PhoneService(ISession session) : base(session)
        {
        }
    }
}