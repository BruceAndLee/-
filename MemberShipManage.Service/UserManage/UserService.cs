using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.UserManage;
using System.Threading.Tasks;

namespace MemberShipManage.Service.UserManage
{
    public class UserService : IUserService
    {
        IUserRepository userRepository;
        IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository
            , IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public Users GetUser(string userNo)
        {
            return userRepository.GetUser(userNo);
        }

        public void UpdatePassword(Users user)
        {
            userRepository.Update(user);
            unitOfWork.Commit();
        }
    }
}
