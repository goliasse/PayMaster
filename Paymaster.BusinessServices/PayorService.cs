using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class PayorService : Repository<Payor>, IPayorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PayorService(ISession session, IUnitOfWork unitOfWork) : base(session)
        {
            _unitOfWork = unitOfWork;
        }
    }
}