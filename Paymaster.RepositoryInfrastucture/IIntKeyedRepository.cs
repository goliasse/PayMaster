namespace Paymaster.RepositoryInfrastucture
{
    public interface IIntKeyedRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(int id);
    }
}