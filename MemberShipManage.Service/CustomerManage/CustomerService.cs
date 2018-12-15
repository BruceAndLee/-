using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Repository.CustomerManage;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CustomerManage
{
    public class CustomerService : BaseService, ICustomerService
    {
        ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public async Task<bool> CheckCustomerExists(string userNo, string password)
        {
            return await customerRepository.CheckCustomerExists(userNo, password);
        }

        public async Task<Customer> GetCustomer(string userNo)
        {
            return await customerRepository.GetCustomer(userNo);
        }

        public async Task<decimal> GetCustomerBalance(string userNo)
        {
            return await customerRepository.GetCustomerBalance(userNo);
        }
    }
}
