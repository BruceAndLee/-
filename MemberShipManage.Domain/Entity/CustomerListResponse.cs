using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class CustomerListResponse
    {
        public List<CustomerEntity> CustomerList { get; set; }
        public int TotalCount { get; set; }
    }
}
