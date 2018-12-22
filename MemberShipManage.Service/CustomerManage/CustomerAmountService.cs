using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Repository.CustomerManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.CustomerManage
{
    public class CustomerAmountService : BaseService, ICustomerAmountService
    {
        ICustomerAmountRepository customerAmountRepository;
        IUnitOfWork unitOfWork;
        public CustomerAmountService(
            ICustomerAmountRepository customerAmountRepository
            , IUnitOfWork unitOfWork)
        {
            this.customerAmountRepository = customerAmountRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateCustomerAmount(CustomerAmount customerAmount)
        {
            customerAmountRepository.CreateCustomerAmount(customerAmount);
            unitOfWork.Commit();
        }
    }
}
