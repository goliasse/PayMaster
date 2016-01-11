using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Paymaster.Model;

namespace Paymaster.App_Start
{
    public class DBPlumbing
    {
        public static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory isessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                .ConnectionString(t => t.FromConnectionStringWithKey("defaultconnection")))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<Employees>())
                .BuildSessionFactory();

            return isessionFactory;
        }
    }
}