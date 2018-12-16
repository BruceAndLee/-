using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Service.UserManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MemberShipManage.Infrastructure;
using MemberShipManage.Utility;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class HomeController : BaseController
    {
        IUserService userService;
        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LoginIn(string userNo, string password, string validateCode)
        {
            var user = await userService.GetUser(userNo);
            if (user == null)
            {
                return ErrorJsonResult(GetMessage("UM_001"));
            }

            var passwordDb = user.Password;
            if (Cryptor.Decrypt(passwordDb) != password)
            {
                return ErrorJsonResult(GetMessage("UM_001"));
            }

            if (Session["ValidateCode"] as string != validateCode)
            {
                return ErrorJsonResult(GetMessage("UM_002"));
            }

            Session["User"] = user;
            return Json(new { IsSuc = 1, User = user });
        }
    }
}