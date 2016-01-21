//using System.Collections.Generic;
//using NHibernate;
//using Paymaster.DBServices.Interfaces;

//namespace Paymaster.DBServices.abstracts
//{
//    public class GenericHibernateDao<T, U> : IGenericDao<T, U>
//    {
//        public ISessionFactory SessionFactory { private get; set; }

//        protected ISession CurrentSession
//        {
//            get
//            {
//                return SessionFactory.GetCurrentSession();
//            }
//        }

//        public virtual T Get(U id)
//        {
//            return CurrentSession.Get<T>(id);
//        }

//        public virtual void Save(T entity)
//        {
//            CurrentSession.Save(entity);
//        }

//        public virtual void Update(T entity)
//        {
//            CurrentSession.Update(entity);
//        }

//        public virtual void Delete(T entity)
//        {
//            CurrentSession.Delete(entity);
//        }

//        public virtual IList<T> GetAll()
//        {
//            return CurrentSession.CreateCriteria(typeof(T))
//                        .List<T>();
//        }
//    }
//}