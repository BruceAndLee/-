using MemberShipManage.Infrastructure.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CustomerService
{
    public interface ICustomerService
    {
        Task<APIBaseResponse> CheckCustomerExists(string userNo, string password);
    }
}
