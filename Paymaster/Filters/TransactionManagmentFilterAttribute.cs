using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NHibernate;
using PayMaster.DataAccess;

namespace Paymaster.Filters
{
    public class TransactionManagmentFilterAttribute : ActionFilterAttribute
    {
        private ISession _session;
        public TransactionManagmentFilterAttribute(ISession session)
        {
            _session = session;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            try
            {
                CloseTransaction(_session);

            }
            finally
            {
                
            }
        }

        private void CloseTransaction(ISession currentSession)
        {
            if (currentSession != null && currentSession.Transaction != null)
            {
                if (currentSession.IsActive())
                {
                    try
                    {
                        currentSession.Flush();

                        if (currentSession.Transaction.IsActive)
                            currentSession.Transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        if (currentSession.Transaction.IsActive) currentSession.Transaction.Rollback();
                        throw;
                    }
                    finally
                    {
                        if (currentSession.IsOpen)
                        {
                            currentSession.Close();
                        }
                    }
                }
            }
        }
    }
}