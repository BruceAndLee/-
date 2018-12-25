using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Domain.Entity
{
    public class UserPwdUpdateRequest
    {
        public string OrgPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
