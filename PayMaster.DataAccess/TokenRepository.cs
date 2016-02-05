using NHibernate;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;

namespace PayMaster.DataAccess
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        public TokenRepository(ISession session) : base(session)
        {
        }
    }
}