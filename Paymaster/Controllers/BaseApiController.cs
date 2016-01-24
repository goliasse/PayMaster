using Paymaster.ActionFilters;
using System.Web.Http;

namespace Paymaster.Controllers
{
    [AuthorizationRequired]
    public class BaseApiController : ApiController
    {
    }
}