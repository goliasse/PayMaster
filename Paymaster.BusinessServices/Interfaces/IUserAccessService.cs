using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;

namespace Paymaster.BusinessServices.Interfaces
{
    public interface IUserAccessService : IIntKeyedRepository<UserAccess>
    {
    }
}