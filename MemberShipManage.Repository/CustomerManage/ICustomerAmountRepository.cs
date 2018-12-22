using MemberShipManage.Domain;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.CustomerManage
{
    public interface ICustomerAmountRepository : IRepository<CustomerAmount>
    {
        void CreateCustomerAmount(CustomerAmount customerAmount);
    }
}
