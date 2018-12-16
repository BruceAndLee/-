using MemberShipManage.Utility;
using System;
using System.Web.Mvc;

namespace MemberShipManage.Infrastructure.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiTrackerFilter : ActionFilterAttribute, IExceptionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            
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
