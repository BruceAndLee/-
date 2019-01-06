using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MemberShipManage.Infrastructure.Filter
{
    public class UserSessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            if (!controllerName.Equals("Login"))
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                if (!string.IsNullOrEmpty(actionName) 
                    && !actionName.Equals("Home") 
                    && !actionName.Equals("Login") 
                    && !actionName.Equals("LoginIn") 
                    && !actionName.Equals("LoginOut"))
                {
                    object sessionUser = filterContext.HttpContext.Session["User"];
                    if (sessionUser == null)
                    {
                        filterContext.HttpContext.Session.Clear();
                        filterContext.RequestContext.HttpContext.Response.Write("<script type='text/javascript'>alert('您已经没有可操作的权限，请重新登录!');window.location.href='/Home/Login';</script>");
                        filterContext.Result = new RedirectResult("/Home/Login");
                    }
                }
            }
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"] as string;
            if (!controllerName.Equals("Login"))
            {
                string actionName = filterContext.RouteData.Values["action"] as string;
                if (!string.IsNullOrEmpty(actionName) 
                    && !actionName.Equals("Home") 
                    && !(actionName.Equals("Login")) 
                    && !actionName.Equals("LoginIn") 
                    && !actionName.Equals("LoginOut")
                    && !actionName.Equals("UpdatePassword"))
                {
                    object sessionUser = filterContext.HttpContext.Session["User"];
                    if (sessionUser == null)
                    {
                        filterContext.Cancel = true;
                    }
                }
            }
        }
    }
}
