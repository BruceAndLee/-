using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
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
    }
}
