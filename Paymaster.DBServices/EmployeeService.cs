using System;
using System.Linq.Expressions;
using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class EmployeeService: BaseDBService<Employees,int>
    {
        //private readonly ISessionFactory _sessionFactory;

        public EmployeeService(ISessionFactory sessionFactory):base(sessionFactory)
        {
        }

        //public Employees FindById(int recordId)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        try
        //        {
        //            return session.QueryOver<Employees>().Where(t => t.Id == recordId).List().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //public bool SoftDeleteEmployee(Employees record)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                record.IsDeleted = true;
        //                session.Update(record);
        //                transaction.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}


        //public bool DeleteEmployee(Employees record)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Delete(record);
        //                transaction.Commit();
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        //public List<Employees> GetAllEmployees()
        //{
        //    using (var session = _sessionFactory.OpenSession())
        //    {
        //        try
        //        {
        //            return session.QueryOver<Employees>().List().ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //public void Save(Employees employee)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Save(employee);
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        //public void Update(Employees employee)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Update(employee);
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        //public void SaveOrUpdate(Employees employee)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.SaveOrUpdate(employee);
        //                transaction.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        //public bool ActivateDeactivateEmployee(int recordId, bool deactivate)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                var employee  =session.Get<Employees>(recordId);
        //                if (employee != null)
        //                {
        //                    employee.IsDeleted = !deactivate;
        //                    session.Update(employee);
        //                    transaction.Commit();
        //                    return true;
        //                }

        //                return false;
        //            }
        //            catch (Exception ex)
        //            {
        //                transaction.Rollback();
        //                throw ex;
        //            }
        //        }
        //    }
        //}

        //protected override bool CompareIds(int src, int dest)
        //{
        //    return src == dest;
        //}
        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }
        //protected internal override Expression<Func<int, bool>> CompareIds(int recordId)
        //{
        //    return (t => t == recordId);
        //}
    }
}