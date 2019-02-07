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
        ICategoryService categoryService;
        public SystemController(
            ISystemService systemService,
            IDishesService dishesService,
            ICategoryService categoryService)
        {
            this.systemService = systemService;
            this.dishesService = dishesService;
            this.categoryService = categoryService;
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

        #region 菜品维护

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
            return PartialView(viewModel);
        }

        [HttpGet]
        public JsonResult Dishes(DishListRequest request)
        {
            var disheses = dishesService.GetDishesList(request);
            return Json(disheses.Select(d => new { d.ID, d.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult DishesGroup(DishListRequest request)
        {
            var disheses = dishesService.GetDishesList(request);
            var dishesGroup = disheses.GroupBy(d => d.CategoryID);
            var dishes = dishesGroup.Select(g => new
            {
                CategoryID = g.Key,
                CategoryName = g.FirstOrDefault() != null ? g.FirstOrDefault().Category.Name : string.Empty,
                DishList = g.Select(r => new { r.ID, r.Name }).ToList()
            });
            return Json(dishes, JsonRequestBehavior.AllowGet);
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
            dish.CategoryID = request.CategoryID;
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

            var dish = new Dishes
            {
                CategoryID = request.CategoryID,
                Name = request.Name
            };

            dishesService.CreateDish(dish);
            return SuccessJsonResult();
        }

        [HttpDelete]
        public JsonResult DeleteDish(int id)
        {
            dishesService.DeleteDish(id);
            return SuccessJsonResult();
        }

        #endregion

        [HttpGet]
        public ViewResult CategoryIndex()
        {
            var categoryList = this.categoryService.GetCategoryList();
            return View(categoryList);
        }

        [HttpGet]
        public JsonResult CategoryList()
        {
            var categoryList = this.categoryService.GetCategoryList();
            var categories = categoryList.Select(c => new
            {
                Id = c.ID,
                Name = c.Name
            });
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateCategory(string categoryName)
        {
            return JsonResult(categoryService.CreateCategory(categoryName));
        }

        [HttpPut]
        public JsonResult UpdateCategory(CategoryUpdateRequest request)
        {
            return JsonResult(categoryService.UpdateCategory(request));
        }

        [HttpDelete]
        public JsonResult RemoveCategory(int categoryID)
        {
            return JsonResult(categoryService.RemoveCategory(categoryID));
        }
    }
}