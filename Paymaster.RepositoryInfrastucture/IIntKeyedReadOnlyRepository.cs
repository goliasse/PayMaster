namespace Paymaster.RepositoryInfrastucture
{
    public interface IIntKeyedReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(int id);
    }
}