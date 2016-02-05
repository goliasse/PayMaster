using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;

namespace Paymaster.Handler
{
    /// <summary>
    /// Creating an Inner "Message" Handler of HTTP for processing of HTTP response ErrorMessages. 
    /// This is used to intercept the calls to RESTFUL Web API Controllers and validate the credentials of the caller.
    /// DelegatingHandler- it is an abstract class provided by Web API to allow easy implementation of message handler
    /// http://www.asp.net/web-api/overview/security/authentication-and-authorization-in-aspnet-web-api
    /// </summary>
    public class SessionTokenAuthenticationMessageHandler : DelegatingHandler
    {
        public const string SessionSchema = "Session";

        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;


        public SessionTokenAuthenticationMessageHandler(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var userName = "";
            var authHeader = request.Headers.Authorization;

            if (authHeader != null && authHeader.Scheme == SessionSchema)
            {
                var tokenEntity = _tokenService.Get(authHeader.Parameter);
                if (tokenEntity != null && tokenEntity.UserId >0)
                {
                    var user = _userService.FindBy(t => t.Id == tokenEntity.UserId);
                    if (user != null)
                    {
                        var roles = _userService.GetRoles(user.Id);
                        SetPrincipal(user, authHeader.Parameter, roles);
                    }
                }
            }

            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;

                try
                {
                    response.Headers.Add("PaymasterCurrentUser", userName);
                }
                catch { }
                return response;
            }, cancellationToken);
        }

        /// <summary>
        /// This method will create an IIdentity & IPrincipal objects
        /// and sets it to HttpContext.Current.User property, so that the IPrincipal
        /// object is available across HttpContext.
        /// </summary>
        /// <param name="user">User data</param>
        /// <param name="sessionToken">Session Token key</param>
        /// /// <param name="roles">Roles</param>
        private static void SetPrincipal(User user, string sessionToken,string[] roles)
        {
            var identity = new GenericIdentity(user.UserName, SessionSchema);

            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.PrimaryGroupSid, user.Payor.Id.ToString()));
            identity.AddClaim(new Claim(CustomClaimType.PayorName.ToString(), user.Payor.Name));
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, sessionToken));

            
            var principal = new GenericPrincipal(identity, roles);

            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }


    }

}