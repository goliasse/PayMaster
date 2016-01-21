using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace Paymaster.App_Start
{
    public class RepositoryModule : NinjectModule
    {
        string connectionString = ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;

    }
}