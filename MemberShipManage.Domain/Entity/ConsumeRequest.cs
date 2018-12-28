using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class ConsumeRequest
    {
        public string UserNo { get; set; }

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
    }
}
