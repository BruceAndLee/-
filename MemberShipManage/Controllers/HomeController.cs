using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Service.UserManage;
using MemberShipManage.Utility;
using System.Web.Mvc;

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
        public JsonResult LoginIn(string userNo, string password, string validateCode)
        {
            var user = userService.GetUser(userNo);
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
            return SuccessJsonResult(response: user);
        }

        public ActionResult LoginOut()
        {
            Session["User"] = null;
            return RedirectToAction("Login");
        }
    }
}