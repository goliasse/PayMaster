using System;

namespace Paymaster.RepositoryInfrastucture
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}