using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class RechargeRecordEntity
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public decimal Amount { get; set; }
        public DateTime? InDate { get; set; }
        public string InUser { get; set; }
    }
}
