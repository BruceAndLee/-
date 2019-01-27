using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class SystemConfigRequest
    {
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string Display { get; set; }
    }
}
