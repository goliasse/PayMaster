using Paymaster.BusinessServices.Interfaces;
using Paymaster.Filters;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using Paymaster.BusinessEntities;

namespace Paymaster.Controllers
{ 
    public class AuthenticateController : ApiController
    {
        #region Private variable.

        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        #endregion Private variable.

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        #endregion Public Constructor

        /// <summary>
        /// Authenticates user usign Basic Authentication(username/password in header) and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        [ApiAuthenticationFilter]
        [HttpGet, ActionName("GenerateToken")]
        public HttpResponseMessage GetGenerateToken()
        {
            if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var userId = basicAuthenticationIdentity.UserId;
                    return GetAuthToken(userId);
                }
            }
            return null;
        }

        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [Route("api/Login")]
        public HttpResponseMessage Post(LoginRequest loginRequest)
        {
            if (loginRequest != null)
            {
                var userId = _userService.Authenticate(loginRequest.Username, loginRequest.Password);
                if (userId > 0)
                {
                    var identity = new BasicAuthenticationIdentity(loginRequest.Username, loginRequest.Password);
                    var genericPrincipal = new GenericPrincipal(identity, null);
                    Thread.CurrentPrincipal = genericPrincipal;
                    var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                    {
                        basicAuthenticationIdentity.UserId = userId;
                        return GetAuthToken(userId);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Logout - logged in user
        /// </summary>
        /// <returns></returns>
        [ApiAuthenticationFilter]
        [Route("api/Logout")]
        public bool Post()
        {
            var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
            if (basicAuthenticationIdentity != null)
            {
                return _tokenService.DeleteByUserId(basicAuthenticationIdentity.UserId);
            }
            return false;
        }

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private HttpResponseMessage GetAuthToken(int userId)
        {
            var token = _tokenService.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry");
            return response;
        }
    }
}