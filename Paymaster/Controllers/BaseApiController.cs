using System.Web.Http;
using Paymaster.ActionFilters;

namespace Paymaster.Controllers
{
    [AuthorizationRequired]
    public class BaseApiController : ApiController
    {
        
    }
}