using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Criterion.Lambda;
using NHibernate.Dialect.Function;
using Paymaster.Model.Interfaces;

namespace Paymaster.DBServices
{
    public abstract class BaseDBService<T, U> : IDBService<T, U> where T : class,IIdAble<U>, IDeletable //where U : IIdAble<U>
    {
        protected readonly ISessionFactory _sessionFactory;
        public BaseDBService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        protected abstract bool CompareIds(U src, U dest);
        
        public T FindById(U recordId)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                try
                {
                    
                    //return session.QueryOver<T>().Where(t => CompareIds(t.Id, recordId)).List().FirstOrDefault();
                    return session.QueryOver<T>().List().Where(t=> CompareIds(t.Id, recordId) ).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Save(T record)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(record);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public List<T> GetAll()
        {
            using (var session = _sessionFactory.OpenSession())
            {
                try
                {
                    return session.QueryOver<T>().List().ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Update(T record)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(record);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void SaveOrUpdate(T record)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(record);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public virtual bool SoftDelete(T record) 
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (!(record is ISoftDeletable))
                        {
                            throw new Exception(string.Format("{0} is not soft deletable", typeof(T)));
                        }

                        var softDeletableRecord = record as ISoftDeletable;
                        softDeletableRecord.IsDeleted = true;
                        session.Update(softDeletableRecord);
                        transaction.Commit();
                        return true;
                       
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public bool Delete(T record)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(record);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


    }
}