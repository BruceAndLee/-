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
        bool CheckCustomerExists(string userNo, string password);
        Customer GetCustomer(string userNo);
        decimal GetCustomerBalance(string userNo);
        IPagedList<Customer> GetCustomerList(CustomerListRequest request);
    }
}
