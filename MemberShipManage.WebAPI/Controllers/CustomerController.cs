using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Service.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MemberShipManage.WebAPI.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [Authorize]
        [HttpGet]
        public async Task<APIBaseResponse> CheckCustomerExists(string userNo, string password)
        {
            return await customerService.CheckCustomerExists(userNo, password);
        }
    }
}