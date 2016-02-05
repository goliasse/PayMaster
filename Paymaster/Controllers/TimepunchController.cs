using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.Security;
using System.Collections.Generic;
using System.Linq;

namespace Paymaster.Controllers
{
    public class TimePunchController : BaseApiController
    {
        private readonly ITimePunchService _timePunchService;
        private readonly IUserSession _userSession;

        public TimePunchController(ITimePunchService timePunchService, IUserSession userSession)
        {
            _timePunchService = timePunchService;
            _userSession = userSession;
        }

        /// <summary>
        /// List all Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TimePunch> Get()
        {
            return _timePunchService.All().Where(t => t.Employees.Id == _userSession.UserId).AsEnumerable();
        }
    }
}