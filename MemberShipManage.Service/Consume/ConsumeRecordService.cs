using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Pagination;
using MemberShipManage.Repository.Consume;
using MemberShipManage.Repository.CustomerManage;
using System.Threading.Tasks;

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

        public async Task<IPagedList<ConsumeRecord>> GetConsumeRecordList(string userNo, int pageIndex, int pageSize)
        {
            var customer = await customerRepository.GetCustomer(userNo);
            return consumeRecordRepository.GetConsumeRecordList(customer.ID, pageIndex, pageSize);
        }
    }
}
