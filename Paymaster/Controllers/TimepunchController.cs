using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Paymaster.Controllers
{
    public class TimePunchController : BaseApiController
    {
        private readonly ITimePunchService _timePunchService;

        public TimePunchController(ITimePunchService timePunchService)
        {
            _timePunchService = timePunchService;
        }

        /// <summary>
        /// List all Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TimePunch> Get()
        {
            //TODO: to be fetched form loggedin user's ID
            var loggedInuser = User.Identity as BasicAuthenticationIdentity;
            if (loggedInuser != null)
                return _timePunchService.All().Where(t => t.Employees.Id == loggedInuser.UserId).AsEnumerable();
            return null;
        }
    }
}