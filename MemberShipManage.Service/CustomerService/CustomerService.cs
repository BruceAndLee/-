using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Repository.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CustomerService
{
    public class CustomerService : BaseService, ICustomerService
    {
        ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<APIBaseResponse> CheckCustomerExists(string userNo, string password)
        {
            var isCustomerExist = await customerRepository.CheckCustomerExists(userNo, password);
            if (!isCustomerExist)
            {
                return BuildAPIErrorResponse("CM_001");
            }

            return BuildAPISucResponse();
        }
    }
}
