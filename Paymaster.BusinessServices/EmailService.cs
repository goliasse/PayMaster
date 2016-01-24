using NHibernate;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using PayMaster.DataAccess;

namespace Paymaster.BusinessServices
{
    public class EmailService : Repository<Email>, IEmailService
    {
        public EmailService(ISession session) : base(session)
        {
        }
    }
}