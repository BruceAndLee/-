using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Utility;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CustomerRepository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public async Task<bool> CheckCustomerExists(string userNo, string password)
        {
            var user = await Task.Run(() => { return dbSet.FirstOrDefault(); });
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
    }
}
