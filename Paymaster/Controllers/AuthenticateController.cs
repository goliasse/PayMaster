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
        //private readonly IUserService _userService;
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
        //[Route("")]
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
        //[Route("")]
        public void Logout()
        {
            _tokenService.Kill(_userSession.SessionToken);
        }

        ///// <summary>
        ///// Authenticates user usign Basic Authentication(username/password in header) and returns token with expiry.
        ///// </summary>
        ///// <returns></returns>
        //public HttpResponseMessage Get()
        //{
        //    if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
        //    {
        //        var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
        //        if (basicAuthenticationIdentity != null)
        //        {
        //            var userId = basicAuthenticationIdentity.UserId;
        //            return GetAuthToken(userId);
        //        }
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Returns auth token for the validated user.
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //private HttpResponseMessage GetAuthToken(int userId)
        //{
        //    var token = _tokenService.GenerateToken(userId);
        //    var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
        //    response.Headers.Add("Token", token.AuthToken);
        //    response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
        //    response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
        //    return response;
        //}
    }
}