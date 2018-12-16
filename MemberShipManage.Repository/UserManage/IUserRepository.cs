using MemberShipManage.Domain;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.UserManage
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> GetUser(string userNo);
    }
}
