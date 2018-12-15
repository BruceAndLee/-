using MemberShipManage.Repository.UserManage;

namespace MemberShipManage.Service.UserManage
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool CheckAppUserExists(string userID, string password)
        {
            return true;
        }
    }
}
