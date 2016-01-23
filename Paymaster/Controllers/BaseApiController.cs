using System.Web.Http;
using System.Web.Mvc;
using Ninject;
using Paymaster.ActionFilters;
using Paymaster.RepositoryInfrastucture;

namespace Paymaster.Controllers
{
    [AuthorizationRequired]
    //[UnitOfWorkAttribute]
    public class BaseApiController : ApiController
    {
    }
}