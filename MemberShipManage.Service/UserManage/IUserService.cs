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
        Task<Users> GetUser(string userID);
    }
}
