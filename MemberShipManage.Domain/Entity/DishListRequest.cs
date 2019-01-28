using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class DishListRequest : PagerEntity
    {
        public string Name { get; set; }
    }
}
