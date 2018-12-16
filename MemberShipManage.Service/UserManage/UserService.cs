using MemberShipManage.Domain;
using MemberShipManage.Repository.UserManage;
using System.Threading.Tasks;

namespace MemberShipManage.Service.UserManage
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Users> GetUser(string userNo)
        {
            return await userRepository.GetUser(userNo);
        }
    }
}
