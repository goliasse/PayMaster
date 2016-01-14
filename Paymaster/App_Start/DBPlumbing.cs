using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Event;
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
                ).
                ExposeConfiguration(val =>
                {
                    val.AppendListeners(ListenerType.PreInsert, new IPreInsertEventListener[] { new PaymasterPreInsertEventListener() });
                    val.AppendListeners(ListenerType.PreUpdate, new IPreUpdateEventListener[] { new PaymasterPreUpdateEventListener() });
                })
                .BuildSessionFactory();

            return isessionFactory;
        }
    }

    public class PaymasterPreInsertEventListener : IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent @event)
        {
            //var modelBase = @event.Entity as ModelBase;

            //if (modelBase != null)
            //{
            //    var currentUtcTime = DateTime.UtcNow;
            //    modelBase.AddedDateTime = currentUtcTime;
            //    modelBase.ModifiedDateTime = currentUtcTime;
            //    Set(@event.Persister, @event.State, "AddedDateTime", currentUtcTime);
            //    Set(@event.Persister, @event.State, "ModifiedDateTime", currentUtcTime);
            //}
            return false;
        }
    }
    public class PaymasterPreUpdateEventListener : IPreUpdateEventListener
    {
        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            //var modelBase = @event.Entity as ModelBase;

            //if (modelBase != null)
            //{
            //    var currentUtcTime = DateTime.UtcNow;
            //    modelBase.ModifiedDateTime = currentUtcTime;
            //    Set(@event.Persister, @event.State, "ModifiedDateTime", currentUtcTime);
            //}
            return false;
        }
    }
}