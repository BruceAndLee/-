using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class RechargeController : BaseController
    {
        // GET: Recharge
        public ActionResult Index()
        {
            return View();
        }
    }
}