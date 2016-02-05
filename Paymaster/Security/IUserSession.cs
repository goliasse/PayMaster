namespace Paymaster.Security
{
    public interface IUserSession
    {
        int UserId { get; }
        int PayorId { get; }
        string PayorName { get; }
        string Username { get; }
        string SessionToken { get; }
    }
}