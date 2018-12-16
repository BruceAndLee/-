using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
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

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> CreateCustomer(Customer customer)
        {
            var response = await customerService.CreateCustomer(customer);
            return JsonResult(response);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateCustomer(Customer customer)
        {
            var response = await customerService.UpdateCustomer(customer);
            return JsonResult(response);
        }

        [HttpPut]
        public async Task<JsonResult> UpdateCustomerPassword(string userNo, string password)
        {
            var response = await customerService.UpdateCustomerPassword(userNo, password);
            return JsonResult(response);
        }
    }
}