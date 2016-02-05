using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class TimePunchService : Repository<TimePunch>, ITimePunchService
    {
        public TimePunchService(ISession session) : base(session)
        {
        }
    }
}