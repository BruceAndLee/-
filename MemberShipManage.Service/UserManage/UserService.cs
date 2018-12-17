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

        public Users GetUser(string userNo)
        {
            return userRepository.GetUser(userNo);
        }
    }
}
