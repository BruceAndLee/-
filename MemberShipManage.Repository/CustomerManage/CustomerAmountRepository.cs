using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CustomerManage
{
    public class CustomerAmountRepository : BaseRepository<CustomerAmount>, ICustomerAmountRepository
    {
        public CustomerAmountRepository(IUnitOfWork dbcontext)
           : base(dbcontext)
        {

        }

        public void CreateCustomerAmount(CustomerAmount customerAmount)
        {
            var customerAmountDb = dbSet.FirstOrDefault(d => d.CustomerID == customerAmount.CustomerID);
            if (customerAmountDb != null)
            {
                customerAmountDb.Amount = Math.Round(customerAmountDb.Amount + customerAmount.Amount, 2);
                Update(customerAmount);
            }
            else
            {
                Insert(customerAmount);
            }
        }
    }
}
