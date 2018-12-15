using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Utility;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CustomerManage
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<bool> CheckCustomerExists(string userNo, string password)
        {
            var user = await GetCustomer(userNo);

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

        public async Task<Customer> GetCustomer(string userNo)
        {
            return await Task.Run(() =>
            {
                return dbSet.FirstOrDefault(d => d.UserNo == userNo);
            });
        }

        public async Task<decimal> GetCustomerBalance(string userNo)
        {
            return await Task.Run(() =>
            {
                var user = dbSet.FirstOrDefault(d => d.UserNo == userNo);
                if (user != null
                    && user.CustomerAmount != null
                    && user.CustomerAmount.Count > 0)
                {
                    return user.CustomerAmount.First().Amount;
                }

                return 0;
            });
        }
    }
}
