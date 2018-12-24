using MemberShipManage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.UserManage
{
    public interface IUserService
    {
        Users GetUser(string userID);
        void UpdatePassword(Users user);
    }
}
