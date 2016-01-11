using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using Paymaster.Model;

namespace Paymaster.DBServices
{
    public class PayorService : BaseDBService<Payors, int>
    {
        private readonly ISessionFactory _sessionFactory;

        public PayorService(ISessionFactory sessionFactory):base(sessionFactory)
        {
            //_sessionFactory = sessionFactory;
        }

        //public Payors FindPayorById(int recordId)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        try
        //        {
        //            return session.QueryOver<Payors>().Where(t => t.Id == recordId).List().FirstOrDefault();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //public List<Payors> GetAllPayors()
        //{
        //    using (var session = _sessionFactory.OpenSession())
        //    {
        //        try
        //        {
        //            return session.QueryOver<Payors>().List().ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //}

        //protected internal override Expression<Func<int, bool>> CompareIds(int recordId)
        //{
        //    return (t => t == recordId);
        //}

        protected override bool CompareIds(int src, int dest)
        {
            return src == dest;
        }

        //public void Save(Payors payor)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Save(payor);
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

        //public void Update(Payors payor)
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            try
        //            {
        //                session.Update(payor);
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

    }
}
