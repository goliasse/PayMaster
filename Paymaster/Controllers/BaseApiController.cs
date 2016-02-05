using System.Web.Http;

namespace Paymaster.Controllers
{
    public class BaseApiController : ApiController
    {
        protected string GetReferrerUrl()
        {
            return Request.Headers.Referrer == null ? this.Request.RequestUri.GetLeftPart(System.UriPartial.Authority) : Request.Headers.Referrer.ToString();
        }
    }
}