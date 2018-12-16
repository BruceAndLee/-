using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CustomerManage
{
    public interface ICustomerService
    {
        Task<bool> CheckCustomerExists(string userNo, string password);
        Task<Customer> GetCustomer(string userNo);
        Task<decimal> GetCustomerBalance(string userNo);
        Task<APIBaseResponse> CreateCustomer(Customer customer);
        Task<APIBaseResponse> UpdateCustomer(Customer customer);
        Task<APIBaseResponse> UpdateCustomerPassword(string userNo, string password);
    }
}
