using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EmployeeDeductionDBService : BaseDBService<Employeedeductions, int>
    {
        public EmployeeDeductionDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
    }
}