using NHibernate;
using Paymaster.App_Start;
using Paymaster.DBServices;
using Paymaster.Model;
using System.Collections.Generic;
using System.Linq;

namespace Paymaster.Controllers
{
    public class TimepunchController : BaseApiController
    {
        private ISessionFactory _sessionFactory;
        private TimepunchDBService _timepunchService;

        public TimepunchController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _timepunchService = new TimepunchDBService(_sessionFactory);
        }

        /// <summary>
        /// List all Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Timepunches> Get()
        {
            //TODO: to be fetched form loggedin user's ID
            int employeeID = 1;//loggedin user ID

            return _timepunchService.GetAll().Where(t => t.Employees.Id == employeeID).AsEnumerable();
        }
    }
}