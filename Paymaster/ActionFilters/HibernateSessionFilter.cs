//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;
//using Paymaster.RepositoryInfrastucture;

//namespace Paymaster.ActionFilters
//{
//    public class HibernateSessionFilter : ActionFilterAttribute
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        public HibernateSessionFilter(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public override void OnActionExecuting(HttpActionContext actionContext)
//        {
//            //CurrentSessionContext.Bind(HibernateConfig.SessionFactory.OpenSession());
//        }

//        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
//        {
//            _unitOfWork.Commit();
//            //ISession session = CurrentSessionContext.Unbind(HibernateConfig.SessionFactory);
//            //session.Flush();
//            //session.Close();
//            //session.Dispose();
//        }
//    }
//}