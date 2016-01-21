using NHibernate;
using Paymaster.DataModel;
using Paymaster.RepositoryInfrastucture;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public interface IPayorService: IIntKeyedRepository<Payors>
    {
        
    }
    public class PayorService : Repository<Payors>, IPayorService
    {
        public PayorService(ISession session) : base(session)
        {
        }
    }
}