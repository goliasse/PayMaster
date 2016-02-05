using System;
using System.Linq;
using System.Linq.Expressions;

namespace Paymaster.RepositoryInfrastucture
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All();
        //TEntity FindBy( Expression<Func<TEntity, bool>> expression);
        //IQueryable<TEntity> FilterBy(Expression<Func<TEntity, bool>> expression);
        TEntity FindBy(Func<TEntity, Boolean> where);
        IQueryable<TEntity> FilterBy(Func<TEntity, Boolean> where);
    }
}