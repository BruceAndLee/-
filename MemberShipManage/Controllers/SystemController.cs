using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Service.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class SystemController : BaseController
    {
        ISystemService systemService;
        public SystemController(ISystemService systemService)
        {
            this.systemService = systemService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var systemConfigs = systemService.GetSystemConfigs();
            return View(systemConfigs);
        }

        [HttpPut]
        public JsonResult Update(SystemConfigRequest request)
        {
            systemService.UpdateSystemConfig(request);
            return SuccessJsonResult();
        }
    }
}