using System.Collections.Generic;
using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EmployeeDBService : BaseDBService<Employees, int>
    {
        public EmployeeDBService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
        
    }
}