using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Models;
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
        IDishesService dishesService;
        public SystemController(
            ISystemService systemService,
            IDishesService dishesService)
        {
            this.systemService = systemService;
            this.dishesService = dishesService;
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

        /// <summary>
        /// 菜品维护
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DishIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DishList(DishListRequest request)
        {
            var dishesList = dishesService.GetDishesList(request);
            var viewModel = new DishesListModel { Name = request.Name };
            viewModel.DishesList = dishesList;
            return View(viewModel);
        }

        [HttpPut]
        public ActionResult UpdateDish(DishUpdateRequest request)
        {
            dishesService.UpdateDish(request);
            return SuccessJsonResult();
        }
    }
}