using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Models;
using MemberShipManage.Service.Consume;
using MemberShipManage.Service.CustomerManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class CustomerController : BaseController
    {
        ICustomerService customerService;
        ICustomerAmountService customerAmountService;
        IConsumeRecordService consumeRecordService;
        public CustomerController(
            ICustomerService customerService
            , ICustomerAmountService customerAmountService
            , IConsumeRecordService consumeRecordService)
        {
            this.customerService = customerService;
            this.customerAmountService = customerAmountService;
            this.consumeRecordService = consumeRecordService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create customer info
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(Customer customer)
        {
            var response = customerService.CreateCustomer(customer);
            return JsonResult(response);
        }

        /// <summary>
        /// Update customer info
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult Update(Customer customer)
        {
            var response = customerService.UpdateCustomer(customer);
            return JsonResult(response);
        }

        /// <summary>
        /// Update customer password
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPut]
        public JsonResult UpdatePassword(string userNo, string password)
        {
            var response = customerService.UpdateCustomerPassword(userNo, password);
            return JsonResult(response);
        }

        /// <summary>
        /// Customer list view
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult List(CustomerListRequest request)
        {
            var customerPagedList = customerService.GetCustomerList(request);
            var viewModel = new CustomerListModel
            {
                Name = request.Name,
                Sex = request.Sex,
                UserNo = request.UserNo,
                CustomerList = customerPagedList
            };

            return View(viewModel);
        }

        /// <summary>
        /// 获取客户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [OutputCache(Duration = 10)]
        public JsonResult CustomerList(CustomerListRequest request)
        {
            var customers = customerService.GetCustomerList(request).ToList();
            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Consume()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateConsume(ConsumeRequest request)
        {
            if (!request.CustomerID.HasValue)
            {
                return JsonResult(new APIBaseResponse(false, "CM_005"));
            }

            var customer = customerService.GetCustomer(request.CustomerID.Value);
            if (customer == null)
            {
                return JsonResult(new APIBaseResponse(false, "CM_002"));
            }

            var customerAmount = customer.CustomerAmount.FirstOrDefault();
            if (customerAmount == null || customerAmount.Amount < request.Amount)
            {
                return JsonResult(new APIBaseResponse(false, "CM_004"));
            }

            customerAmount.Amount = customerAmount.Amount - request.Amount;
            customerAmountService.UpdateCustomerAmount(customerAmount);
            var consumeRecord = Mapper.Map<ConsumeRecord>(request);
            consumeRecordService.CreateConsumeRecord(consumeRecord);
            return SuccessJsonResult();
        }
    }
}