using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
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
                .FluentMappings.AddFromAssemblyOf<Employees>()
                .Conventions.Add(Table.Is((t => t.TableName.ToLower())))
                )
                .BuildSessionFactory();

            return isessionFactory;
        }
    }
}