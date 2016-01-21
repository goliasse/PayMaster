using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paymaster.DBServices.Interfaces;

namespace Paymaster.DBServices
{
    public class AuthenticationServices : IAuthenticationServices
    {
        //public AuthenticationServices(IUnitOfWork unitOfWork)
        //{
            
        //}
        public bool Authenticate(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
