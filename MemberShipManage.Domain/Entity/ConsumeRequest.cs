using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class ConsumeRequest
    {
        public int? CustomerID { get; set; }

        private decimal amount;
        public decimal Amount
        {
            get
            {
                return Math.Round(amount, 2);
            }
            set
            {
                amount = value;
            }
        }

        public string Detail { get; set; }
        public string InUser { get; set; }
        public decimal DiscountRatio { get; set; }
        public decimal KickbackRatio { get; set; }
        public string UserID { get; set; }
    }
}
