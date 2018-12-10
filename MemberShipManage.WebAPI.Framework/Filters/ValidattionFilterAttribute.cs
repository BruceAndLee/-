using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace MemberShipManage.WebAPI.Framework.Filters
{
    public class ValidattionFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}
