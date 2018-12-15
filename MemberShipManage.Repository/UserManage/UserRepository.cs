using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.UserManage
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }
    }
}
