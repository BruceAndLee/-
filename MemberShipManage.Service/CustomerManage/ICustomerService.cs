using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.CustomerManage
{
    public interface ICustomerService
    {
        bool CheckCustomerExists(string userNo, string password);
        Customer GetCustomer(string userNo);
        Customer GetCustomer(int customerID);
        decimal GetCustomerBalance(string userNo);
        APIBaseResponse CreateCustomer(Customer customer);
        APIBaseResponse UpdateCustomer(Customer customer);
        APIBaseResponse UpdateCustomerPassword(string userNo, string password);
        IPagedList<Customer> GetCustomerList(CustomerListRequest request);
    }
}
