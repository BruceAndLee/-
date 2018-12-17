using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Utility;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.CustomerManage
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public bool CheckCustomerExists(string userNo, string password)
        {
            var user = GetCustomer(userNo);

            if (user == null)
            {
                return false;
            }

            var passwordDb = Cryptor.Decrypt(user.Password);
            if (password != passwordDb)
            {
                return false;
            }

            return true;
        }

        public Customer GetCustomer(string userNo)
        {
            return dbSet.FirstOrDefault(d => d.UserNo == userNo);
        }

        public decimal GetCustomerBalance(string userNo)
        {
            var user = dbSet.FirstOrDefault(d => d.UserNo == userNo);
            if (user != null
                && user.CustomerAmount != null
                && user.CustomerAmount.Count > 0)
            {
                return user.CustomerAmount.First().Amount;
            }

            return 0;
        }

        public IPagedList<Customer> GetCustomerList(CustomerListRequest request)
        {
            IQueryable<Customer> query = this.dbSet;
            if (!string.IsNullOrEmpty(request.UserNo))
            {
                query = query.Where(q => q.UserNo.Contains(request.UserNo));
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(q => q.Name.Contains(request.Name));
            }

            if (request.Sex.HasValue)
            {
                query = query.Where(q => q.Sex == request.Sex);
            }

            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<Customer>(query, request.PageIndex, request.PageSize);
        }
    }
}
