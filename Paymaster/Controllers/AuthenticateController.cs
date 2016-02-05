using Paymaster.BusinessServices.Interfaces;
using Paymaster.Filters;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using Paymaster.BusinessEntities;
using Paymaster.Security;

namespace Paymaster.Controllers
{ 
    /// <summary>
    /// Provides API for authentication mechanism
    /// </summary>
    //[ApiAuthenticationFilter()]
    public class AuthenticateController : ApiController
    {
        #region Private variable.

        private readonly ITokenService _tokenService;
        private readonly IUserSession _userSession;
        #endregion Private variable.

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateController(ITokenService tokenService,  IUserSession userSession)
        {
            _tokenService = tokenService;
            _userSession = userSession;
        }

        #endregion Public Constructor

        /// <summary>
        /// Login: Returns auth token for the validated user.
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public TokenEntity Login([FromBody] LoginRequest loginRequest)
        {
            var token = _tokenService.AuthenticateUser(loginRequest.Username, loginRequest.Password);
            if (token == null) throw new HttpResponseException(HttpStatusCode.Unauthorized);
            return token;
        }

        /// <summary>
        /// Logout : Invalidates the current session
        /// </summary>
        [HttpDelete]
        public void Logout()
        {
            _tokenService.Kill(_userSession.SessionToken);
        }
        
    }
}