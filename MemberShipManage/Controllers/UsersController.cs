using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Service.UserManage;
using MemberShipManage.Utility;
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

        [HttpGet]
        public ViewResult Password()
        {
            return View();
        }

        [HttpPut]
        public JsonResult UpdatePassword(UserPwdUpdateRequest request)
        {
            var currentUser = Session["User"] as Users;
            if (currentUser == null)
            {
                return JsonResult(new APIBaseResponse(false, "UM_004"));
            }

            var userDb = userService.GetUser(currentUser.UserNo);
            if (userDb == null)
            {
                return JsonResult(new APIBaseResponse { IsSuccess = false, ResponseCode = "UM_003" });
            }

            if (Cryptor.Decrypt(userDb.Password) != request.OrgPassword)
            {
                return JsonResult(new APIBaseResponse(false, "UM_005"));
            }

            userDb.Password = Cryptor.Encrypt(request.NewPassword.Trim());
            userService.UpdatePassword(userDb);
            Session["User"] = null;
            return SuccessJsonResult();
        }
    }
}