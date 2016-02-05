using System.Security.Principal;
using System.Threading;
using System.Web.Http;
using Ninject.Web.WebApi;
using Paymaster.ActionFilters;
using Paymaster.Filters;
using Paymaster.Handler;
using PayMaster.DataAccess;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Paymaster.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Paymaster.App_Start.NinjectWebCommon), "Stop")]

namespace Paymaster.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Security;
    using Ninject.Activation;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Settings.AllowNullInjection = true;
            var resolver = new NinjectDependencyResolver(kernel);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch(Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var containerConfigurator = new NinjectConfigurator();
            containerConfigurator.Configure(kernel);
            //Modules
            kernel.Load(new RepositoryModule());
            kernel.Load(new BusinessServiceModule());
            
            //Handlers
            GlobalConfiguration.Configuration.MessageHandlers.Add(kernel.Get<OptionsHandler>());
            GlobalConfiguration.Configuration.MessageHandlers.Add(kernel.Get<SessionTokenAuthenticationMessageHandler>());

            //Filters
            //GlobalConfiguration.Configuration.Filters.Add(kernel.Get<LoggingFilterAttribute>());
            //GlobalConfiguration.Configuration.Filters.Add(kernel.Get<GlobalExceptionAttribute>());
            GlobalConfiguration.Configuration.Filters.Add(new AuthorizeAttribute());
        }

        
    }
}
