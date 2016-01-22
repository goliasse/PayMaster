using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class PayorService : Repository<Payors>, IPayorService
    {
        private readonly ISession _session;
        private readonly IUnitOfWork _unitOfWork;

        public PayorService(ISession session, IUnitOfWork unitOfWork) : base(session)
        {
            _session = session;
            _unitOfWork = unitOfWork;
        }
    }
}