using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Engine;
using NHibernate.Event;
using NHibernate.Event.Default;
using NHibernate.Persister.Entity;
using Paymaster.Model.Interfaces;

namespace Paymaster.Model.Events
{
    public class SoftDeletableLoadEventListener : DefaultLoadEventListener
    {
        protected override object DoLoad(LoadEvent @event, IEntityPersister persister, EntityKey keyToLoad,
            LoadType options)
        {
            object entity = base.DoLoad(@event, persister, keyToLoad, options);

            var softEntity = entity as ISoftDeletable;

            if (softEntity != null && softEntity.IsDeleted)
            {
                if (options == LoadEventListener.ImmediateLoad
                    || options == LoadEventListener.Load)
                {
                    //string msg =
                    //    string.Format("Can not Load soft deleted entity typeof({0}) with Id {1} as it was deleted.",
                    //        softEntity.GetType().Name,
                    //        softEntity.Id);

                    //throw new InvalidOperationException(msg);
                    throw new InvalidOperationException();
                }
            }

            return entity;
        }
    }
}
