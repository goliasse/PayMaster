using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Linq;
using Paymaster.RepositoryInfrastucture;
using System.Linq;
using System.Linq.Expressions;

namespace PayMaster.DataAccess
{
    //public abstract class Repository<T> : NHibernateContext, IIntKeyedRepository<T> where T : class
    public abstract class Repository<T> : IIntKeyedRepository<T> where T : class
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        #region IRepository<T> Members

        public virtual bool Add(T entity)
        {
            _session.Save(entity);
            return true;
        }

        public virtual bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public virtual bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public virtual bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }
        public virtual bool Delete(Expression<System.Func<T, bool>> expression)
        {
            var objects = All().Where(expression).AsQueryable();
            foreach (var obj in objects)
                _session.Delete(obj);
            return true;
        }

        public virtual bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }

        #endregion IRepository<T> Members

        #region IIntKeyedRepository<T> Members

        public virtual T FindBy(int id)
        {
            return _session.Get<T>(id);
        }

        #endregion IIntKeyedRepository<T> Members

        #region IReadOnlyRepository<T> Members

        public virtual IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        //public virtual T FindBy(Expression<System.Func<T, bool>> expression)
        //{
        //    return FilterBy(expression).Single();
        //}

        //public virtual IQueryable<T> FilterBy(Expression<System.Func<T, bool>> expression)
        //{
        //    return All().Where(expression).AsQueryable();
        //}

        public virtual T FindBy(Func<T, Boolean> where)
        {
            return FilterBy(where).SingleOrDefault();
        }
        public virtual IQueryable<T> FilterBy(Func<T, Boolean> where)
        {
            return All().Where(where).AsQueryable();
        }

        #endregion IReadOnlyRepository<T> Members
    }
}