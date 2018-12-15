using MemberShipManage.Domain;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CustomerManage
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> CheckCustomerExists(string userNo, string password);
        Task<Customer> GetCustomer(string userNo);
        Task<decimal> GetCustomerBalance(string userNo);
    }
}
