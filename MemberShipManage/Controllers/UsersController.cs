using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Service.UserManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class UsersController : BaseController
    {
        IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public JsonResult UpdatePassword(Users user)
        {
            var userDb = userService.GetUser(user.UserNo);
            if (userDb == null)
            {
                return JsonResult(new APIBaseResponse { IsSuccess = false, ResponseCode = "UM_003" });
            }

            userService.UpdatePassword(user);
            return SuccessJsonResult();
        }
    }
}