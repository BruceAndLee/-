using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class DishUpdateRequest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }
}
