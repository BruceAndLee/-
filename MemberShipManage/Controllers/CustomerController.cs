using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Models;
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
        public CustomerController(
            ICustomerService customerService)
        {
            this.customerService = customerService;
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
    }
}