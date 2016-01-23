using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Paymaster.RepositoryInfrastucture;

namespace Paymaster.ActionFilters
{
    public class UnitOfWorkAttribute : ActionFilterAttribute
    {
        // this property is injected by DI (before action executes)
        // this post won't cover how this DI inject work.
        // for more info, please download the attached sample project..
        [Inject]
        public IUnitOfWork UnitOfWork { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
                UnitOfWork.BeginTransaction();
        }

        // after action executed
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (filterContext.Exception == null)
            {
                this.UnitOfWork.Commit();
            }
        }



        //protected override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    if (!filterContext.IsChildAction)
        //        UnitOfWork.Commit();
        //}

    }
}