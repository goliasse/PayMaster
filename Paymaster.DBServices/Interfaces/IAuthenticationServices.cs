namespace Paymaster.DBServices.Interfaces
{
    public interface IAuthenticationServices
    {
        bool Authenticate(string userName, string password);
    }
}