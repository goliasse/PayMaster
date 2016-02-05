using System;

namespace Paymaster.RepositoryInfrastucture
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();

        void Rollback();
    }
}