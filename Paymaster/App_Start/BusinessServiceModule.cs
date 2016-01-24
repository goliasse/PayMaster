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
            Bind<IAddressService>().To<AddressService>();
            Bind<IEmailService>().To<EmailService>();
            Bind<IPayorService>().To<PayorService>();
            Bind<ITimePunchService>().To<TimePunchService>();
            Bind<IPhoneService>().To<PhoneService>();
            Bind<ITokenService>().To<TokenService>();
            Bind<IUserService>().To<UserService>();
            Bind<ICheckService>().To<CheckService>();
            Bind<IEarningService>().To<EarningService>();
            Bind<IEmployeeDeductionService>().To<EmployeeDeductionService>();
            Bind<IFedAllowanceService>().To<FedAllowanceService>();
            Bind<IFedTaxTableService>().To<FedTaxTableService>();
            Bind<IPayorVariableService>().To<PayorVariableService>();
            Bind<IPayPeriodService>().To<PayPeriodService>();
            Bind<IUserAccessService>().To<UserAccessService>();

        }
    }
}