using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class EmployeeDeductionService : Repository<EmployeeDeduction>, IEmployeeDeductionService
    {
        public EmployeeDeductionService(ISession session) : base(session)
        {
        }
    }
}