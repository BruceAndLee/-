using MemberShipManage.Domain;
using MemberShipManage.Repository.Consume;
using MemberShipManage.Repository.CustomerManage;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.Consume
{
    public class ConsumeRecordService : IConsumeRecordService
    {
        ICustomerRepository customerRepository;
        IConsumeRecordRepository consumeRecordRepository;
        public ConsumeRecordService(
            IConsumeRecordRepository consumeRecordRepository
            , ICustomerRepository customerRepository)
        {
            this.consumeRecordRepository = consumeRecordRepository;
            this.customerRepository = customerRepository;
        }

        public IPagedList<ConsumeRecord> GetConsumeRecordList(string userNo, int pageIndex, int pageSize)
        {
            var customer = customerRepository.GetCustomer(userNo);
            return consumeRecordRepository.GetConsumeRecordList(customer.ID, pageIndex, pageSize);
        }
    }
}
