using System;

namespace Paymaster.RepositoryInfrastucture
{
    public interface IGuidKeyedRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(Guid id);
    }
}