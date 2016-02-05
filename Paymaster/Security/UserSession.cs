using System.Security.Claims;
using Paymaster.Handler;

namespace Paymaster.Security
{
    public class UserSession : IUserSession
    {
        #region Constructor

        public UserSession(ClaimsPrincipal principal)
        {
            UserId = int.Parse(principal.FindFirst(ClaimTypes.Sid).Value);
            SessionToken = principal.FindFirst(ClaimTypes.PrimarySid).Value;
            PayorId = int.Parse(principal.FindFirst(ClaimTypes.PrimaryGroupSid).Value);
            PayorName = principal.FindFirst(CustomClaimType.PayorName.ToString()).Value;
            Username = principal.FindFirst(ClaimTypes.Name).Value;
        }

        #endregion Constructor

        public int UserId { get; private set; }
        public int PayorId { get; private set; }
        public string PayorName { get; private set; }
        public string Username { get; private set; }
        public string SessionToken { get; private set; }
    }
}