using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.UserManage
{
    public interface IUserService
    {
        bool CheckAppUserExists(string userID, string password);
    }
}
