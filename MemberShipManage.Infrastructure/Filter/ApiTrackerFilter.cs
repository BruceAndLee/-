using MemberShipManage.Utility;
using System;
using System.Web.Mvc;
using System.Linq;
using MemberShipManage.Domain;

namespace MemberShipManage.Infrastructure.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiTrackerFilter : ActionFilterAttribute, IExceptionFilter
    {
        private readonly string INDATE = "InDate";
        private readonly string LASTEDITDATE = "LastEditDate";
        private readonly string INUSER = "InUser";
        private readonly string LASTEDITUSER = "LastEditUser";
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var actionParameters = actionContext.ActionParameters;
            if (actionParameters != null && actionParameters.Count > 0)
            {
                var dateFields = actionParameters.Keys.Where(k => k == INDATE || k == LASTEDITDATE);
                foreach (var dateField in dateFields)
                {
                    actionParameters[dateField] = DateTime.Now;
                }

                var userFields = actionParameters.Keys.Where(k => k == INUSER || k == LASTEDITUSER);
                var currentUser = (actionContext.HttpContext.Session["User"] as Users);
                foreach (var userField in userFields)
                {
                    actionParameters[userField] = currentUser != null ? currentUser.UserNo : string.Empty;
                }
            }
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {

        }

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                string controllerName = string.Format("{0}Controller", filterContext.RouteData.Values["controller"] as string);
                string actionName = filterContext.RouteData.Values["action"] as string;
                string errorMsg = string.Format("在执行 controller[{0}] 的 action[{1}] 时产生异常", controllerName, actionName);
                LogHelper.Error(errorMsg, filterContext.Exception);
            }
        }
    }
}
