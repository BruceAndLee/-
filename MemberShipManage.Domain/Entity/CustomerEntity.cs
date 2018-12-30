using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class CustomerEntity
    {
        public int ID { get; set; }
        public string UserNo { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public int? Sex { get; set; }
        public string ParentCustomerName { get; set; }
        public int? ParentCustomerID { get; set; }
        public string InUser { get; set; }
        public DateTime? InDate { get; set; }
    }
}
