using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MemberShipManage.Infrastructure.Base
{
    [ApiTrackerFilter]
    public class BaseController : Controller
    {
        public string GetMessage(string resourceID)
        {
            return MsgResourceBuilder.GetMessageResource(resourceID);
        }

        protected JsonResult SuccessJsonResult(string message = "保存成功！", JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Json(new { IsSuc = true, Msg = message });
        }

        protected JsonResult SuccessJsonResult<Response>(string message = "保存成功！", Response response = null, JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
            where Response : class, new()
        {
            return Json(new { IsSuc = true, Msg = message, Response = response });
        }

        protected JsonResult ErrorJsonResult(string message = "保存失败！", JsonRequestBehavior behavior = JsonRequestBehavior.AllowGet)
        {
            return Json(new { IsSuc = false, Msg = message });
        }

        protected JsonResult JsonResult(APIBaseResponse response)
        {
            if (!response.IsSuccess)
            {
                return ErrorJsonResult(GetMessage(response.ResponseCode));
            }

            return SuccessJsonResult();
        }
    }
}
