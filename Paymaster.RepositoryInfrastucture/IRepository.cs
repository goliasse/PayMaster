using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Paymaster.RepositoryInfrastucture
{
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        bool Add(TEntity entity);

        bool Add(IEnumerable<TEntity> items);

        bool Update(TEntity entity);

        bool Delete(TEntity entity);

        bool Delete(IEnumerable<TEntity> entities);

        bool Delete(Expression<Func<TEntity, bool>> expression);
    }
}