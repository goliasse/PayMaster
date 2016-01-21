using NHibernate;
using NHibernate.Linq;
using Paymaster.RepositoryInfrastucture;
using System.Linq;

namespace PayMaster.DataAccess
{
    public abstract class Repository<T> : NHibernateContext, IIntKeyedRepository<T> where T : class
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

        public virtual bool Add(System.Collections.Generic.IEnumerable<T> items)
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

        public virtual bool Delete(System.Collections.Generic.IEnumerable<T> entities)
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
            return _session.Linq<T>();
        }

        public virtual T FindBy(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return FilterBy(expression).Single();
        }

        public virtual IQueryable<T> FilterBy(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }

        #endregion IReadOnlyRepository<T> Members
    }
}