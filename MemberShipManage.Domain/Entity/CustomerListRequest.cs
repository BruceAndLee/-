using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class CustomerListRequest : PagerEntity
    {
        public string UserNo { get; set; }
        public string Name { get; set; }
        public int? Sex { get; set; }
    }
}
