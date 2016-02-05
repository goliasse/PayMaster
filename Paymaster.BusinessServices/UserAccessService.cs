using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class UserAccessService : Repository<UserAccess>, IUserAccessService
    {
        public UserAccessService(ISession session) : base(session)
        {
        }
    }
}