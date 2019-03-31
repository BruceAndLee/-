using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.CustomerManage
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerInfo(string userNo, string password);
        Customer GetCustomer(string userNo);
        Customer GetCustomer(int customerID);
        decimal GetCustomerBalance(string userNo);
        PagedList<CustomerEntity> GetCustomerList(CustomerListRequest request);
        List<CustomerRebateEntity> GetCustomerRebateList(int customerID);
    }
}
