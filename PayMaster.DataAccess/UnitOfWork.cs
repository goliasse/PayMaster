using NHibernate;
using Paymaster.RepositoryInfrastucture;
using System;
using System.Data;

namespace PayMaster.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;
        public ISession Session { get; private set; }

        public UnitOfWork(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            Session = _sessionFactory.OpenSession();
            Session.FlushMode = FlushMode.Auto;
            _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Dispose()
        {
            if (Session.IsOpen)
            {
                Commit();//commit before disposing
                Session.Close();
            }
            Session = null;
        }

        //public void BeginTransaction()
        //{
        //    _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        //}

        public void Commit()
        {
            if (!_transaction.IsActive)
            {
                throw new InvalidOperationException("No active transation");
            }
            _transaction.Commit();
        }

        public void Rollback()
        {
            if (_transaction.IsActive)
            {
                _transaction.Rollback();
            }
        }
    }
}