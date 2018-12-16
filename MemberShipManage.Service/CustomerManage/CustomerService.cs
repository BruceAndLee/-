using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.CustomerManage;
using MemberShipManage.Utility;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CustomerManage
{
    public class CustomerService : BaseService, ICustomerService
    {
        ICustomerRepository customerRepository;
        IUnitOfWork unitOfWork;
        public CustomerService(
            ICustomerRepository customerRepository
            , IUnitOfWork unitOfWork)
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

        public async Task<APIBaseResponse> CreateCustomer(Customer customer)
        {
            var response = new APIBaseResponse { IsSuccess = true };
            var customerDb = await customerRepository.GetCustomer(customer.UserNo);
            if (customerDb != null)
            {
                response.IsSuccess = false;
                response.ResponseCode = "CM_001";
                return response;
            }

            customerRepository.Insert(customer);
            unitOfWork.Commit();
            return response;
        }

        public async Task<APIBaseResponse> UpdateCustomer(Customer customer)
        {
            var response = new APIBaseResponse { IsSuccess = true };
            var customerDb = await customerRepository.GetCustomer(customer.UserNo);
            if (customerDb == null)
            {
                response.IsSuccess = false;
                response.ResponseCode = "COM_001";
                return response;
            }

            customerDb.Name = customer.Name;
            customerDb.Sex = customer.Sex;
            customerDb.UserNo = customer.UserNo;
            customerRepository.Update(customerDb);
            unitOfWork.Commit();
            return response;
        }

        public async Task<APIBaseResponse> UpdateCustomerPassword(string userNo, string password)
        {
            var response = new APIBaseResponse { IsSuccess = true };
            var customerDb = await customerRepository.GetCustomer(userNo);
            if (customerDb == null)
            {
                response.IsSuccess = false;
                response.ResponseCode = "COM_001";
                return response;
            }

            customerDb.Password = Cryptor.Encrypt(password);
            return response;
        }
    }
}
