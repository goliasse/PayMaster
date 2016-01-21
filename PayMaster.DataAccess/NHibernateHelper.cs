using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System.Reflection;

namespace PayMaster.DataAccess
{
    public class NHibernateHelper
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
                .Mappings(m =>
                m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                //m.FluentMappings.AddFromAssemblyOf<Employees>()
                .Conventions.Add(Table.Is((t => t.TableName.ToLower()))))
                //.ExposeConfiguration(val =>
                //{
                //    val.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new PaymasterPreInsertEventListener() });
                //    val.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new PaymasterPreUpdateEventListener() });
                //})
                .BuildSessionFactory();
        }
    }
}