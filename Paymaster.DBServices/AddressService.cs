using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class AddressService : BaseDBService<Addresses, int>
    {
        public AddressService(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }

        
    }
}
