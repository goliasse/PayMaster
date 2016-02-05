using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class EmployeeService : Repository<Employee>, IEmployeeService
    {
        public EmployeeService(ISession session) : base(session)
        {
        }
    }
}