using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;

namespace Paymaster.BusinessServices.Interfaces
{
    public interface IUserService : IIntKeyedRepository<User>
    {
        int Authenticate(string userName, string password);
        string[] GetRoles(int UserId);
    }
}