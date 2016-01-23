using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class EmployeeService : Repository<Employee>, IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(ISession session, IUnitOfWork unitOfWork) : base(session)
        {
            _unitOfWork = unitOfWork;
        }
    }
}