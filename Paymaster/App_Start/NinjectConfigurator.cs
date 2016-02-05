using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using Ninject;
using Ninject.Activation;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using Paymaster.Security;

namespace Paymaster.App_Start
{
    public class NinjectConfigurator
    {
        /// <summary>
        /// This method is an entry point to NinjectConfigurator class 
        /// </summary>
        /// <param name="container">Standard Kernel Object of Ninject</param>
        public void Configure(IKernel container)
        {
            AddBindings(container);

            //var resolver = new NinjectDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        /// <summary>
        /// This method will either directly bind or call other configuration methods
        /// </summary>
        /// <param name="container">Standard Kernel Object of Ninject</param>
        private void AddBindings(IKernel container)
        {
            container.Bind<IUserSession>().ToMethod(CreateUserSession).InRequestScope();
            //container.Bind<IUserSession>().To<UserSession>();
        }

        /// <summary>
        /// Returns the IPrincipal object from current thread.
        /// </summary>
        /// <param name="arg">IContext</param>
        /// <returns>User Session</returns>
        private IUserSession CreateUserSession(IContext arg)
        {
            var principal = Thread.CurrentPrincipal as GenericPrincipal;
            var responseSesssion = principal != null ? new UserSession(Thread.CurrentPrincipal as GenericPrincipal) : null;
            return responseSesssion;
        }
    }
}