using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.CustomerManage;
using MemberShipManage.Utility;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.CustomerManage
{
    public class CustomerService : BaseService, ICustomerService
    {
        ICustomerRepository customerRepository;
        ICustomerAmountRepository customerAmountRepository;
        IUnitOfWork unitOfWork;
        public CustomerService(
            ICustomerRepository customerRepository
            , ICustomerAmountRepository customerAmountRepository
            , IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.customerAmountRepository = customerAmountRepository;
            this.unitOfWork = unitOfWork;
        }

        #region Customer

        public bool CheckCustomerExists(string userNo, string password)
        {
            return customerRepository.CheckCustomerExists(userNo, password);
        }

        public Customer GetCustomer(string userNo)
        {
            return customerRepository.GetCustomer(userNo);
        }

        public Customer GetCustomer(int customerID)
        {
            return customerRepository.GetCustomer(customerID);
        }

        public decimal GetCustomerBalance(string userNo)
        {
            return customerRepository.GetCustomerBalance(userNo);
        }

        public APIBaseResponse CreateCustomer(Customer customer)
        {
            var response = new APIBaseResponse { IsSuccess = true };
            var customerDb = customerRepository.GetCustomer(customer.UserNo);
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

        public APIBaseResponse UpdateCustomer(Customer customer)
        {
            var response = new APIBaseResponse { IsSuccess = true };
            var customerDb = customerRepository.GetCustomer(customer.UserNo);
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

        public APIBaseResponse UpdateCustomerPassword(string userNo, string password)
        {
            var response = new APIBaseResponse { IsSuccess = true };
            var customerDb = customerRepository.GetCustomer(userNo);
            if (customerDb == null)
            {
                response.IsSuccess = false;
                response.ResponseCode = "COM_001";
                return response;
            }

            customerDb.Password = Cryptor.Encrypt(password);
            return response;
        }

        public IPagedList<CustomerEntity> GetCustomerList(CustomerListRequest request)
        {
            return customerRepository.GetCustomerList(request);
        }

        #endregion
    }
}
