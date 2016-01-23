using Ninject.Modules;
using Paymaster.BusinessServices;
using Paymaster.BusinessServices.Interfaces;

namespace Paymaster.App_Start
{
    public class BusinessServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IPayorService>().To<PayorService>();
            Bind<ITokenService>().To<TokenService>();
            Bind<IUserService>().To<UserService>();
            
        }
    }
}