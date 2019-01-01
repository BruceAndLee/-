using MemberShipManage.Utility;
using System;
using System.Web.Mvc;
using System.Linq;
using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Extension;

namespace MemberShipManage.Infrastructure.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class ApiTrackerFilter : ActionFilterAttribute, IExceptionFilter
    {
        private readonly string INDATE = "InDate";
        private readonly string LASTEDITDATE = "LastEditDate";
        private readonly string INUSER = "InUser";
        private readonly string UserID = "UserID";
        private readonly string LASTEDITUSER = "LastEditUser";
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.HttpMethod == "GET")
            {
                return;
            }

            var actionParameters = actionContext.ActionParameters;
            if (actionParameters != null && actionParameters.Count > 0)
            {
                var actionValue = actionParameters.First().Value;
                actionValue.SetObjectValue(INDATE, DateTime.Now);
                actionValue.SetObjectValue(LASTEDITDATE, DateTime.Now);

                var currentUser = (actionContext.HttpContext.Session["User"] as Users);
                if (currentUser != null)
                {
                    actionValue.SetObjectValue(UserID, currentUser.UserNo);
                    actionValue.SetObjectValue(INUSER, currentUser.UserNo);
                    actionValue.SetObjectValue(LASTEDITUSER, currentUser.UserNo);
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
