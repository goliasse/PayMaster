using System;

namespace Paymaster.RepositoryInfrastucture
{
    public interface IGuidKeyedReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(Guid id);
    }
}