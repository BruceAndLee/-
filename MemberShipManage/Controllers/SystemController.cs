using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
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

        [HttpGet]
        public JsonResult Dishes(DishListRequest request)
        {
            var disheses = dishesService.GetDishesList(request);
            return Json(disheses.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateDish(DishUpdateRequest request)
        {
            var dish = dishesService.GetDish(request.ID);
            if (dish == null)
            {
                return JsonResult(new APIBaseResponse { IsSuccess = false, ResponseCode = "COM_001" });
            }

            var isDishNameExist = dishesService.CheckDishNameExists(request.ID, request.Name);
            if (isDishNameExist)
            {
                return JsonResult(new APIBaseResponse { IsSuccess = false, ResponseCode = "DISH_001" });
            }

            dish.Name = request.Name;
            dishesService.UpdateDish(dish);
            return SuccessJsonResult();
        }

        [HttpPost]
        public JsonResult CreateDish(DishUpdateRequest request)
        {
            var isDishNameExist = dishesService.CheckDishNameExists(null, request.Name);
            if (isDishNameExist)
            {
                return JsonResult(new APIBaseResponse { IsSuccess = false, ResponseCode = "DISH_001" });
            }

            dishesService.CreateDish(request.Name);
            return SuccessJsonResult();
        }

        [HttpDelete]
        public JsonResult DeleteDish(int id)
        {
            dishesService.DeleteDish(id);
            return SuccessJsonResult();
        }
    }
}