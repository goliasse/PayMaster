using System.Globalization;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using System.Reflection;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using System;
using System.Configuration;
using System.Data.Entity.Design.PluralizationServices;
using System.IO;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;

namespace PayMaster.DataAccess
{
    public class NHibernateHelper
    {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory ?? (_sessionFactory = CreateSessionFactory<WebSessionContext>());
            }
        }

        public NHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory CreateSessionFactory<T>() where T : ICurrentSessionContext
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
                .Mappings(m =>
                    m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                    .Conventions.Add<TableNameConvention>()
                )
                //.ExposeConfiguration(val =>
                //{
                //    val.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new PaymasterPreInsertEventListener() });
                //    val.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new PaymasterPreUpdateEventListener() });
                //})
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false)) //this line creates the database tables in target db
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)) //this line creates the database tables in target db
                .ExposeConfiguration(x => x.SetProperty("current_session_context_class", "web"))
                //.CurrentSessionContext<T>()// (ConfigurationManager.AppSettings["NinjectSessionContextClass"])
                .BuildSessionFactory();
        }
        
    }

    public class TableNameConvention : IClassConvention
    {
        public void Apply(IClassInstance instance)
        {
            string typeName = instance.EntityType.Name;
            var tableName = PluralizationService.CreateService(CultureInfo.CurrentCulture).Pluralize(typeName);
            var tableNameLowerCase = tableName.ToLower();
            instance.Table(tableNameLowerCase);

        }
    }
}