using NHibernate;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;

namespace PayMaster.DataAccess
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISession session) : base(session)
        {
        }
    }
}