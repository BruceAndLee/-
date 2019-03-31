using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
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
        IUnitOfWork unitOfWork;
        public ConsumeRecordService(
            IConsumeRecordRepository consumeRecordRepository
            , ICustomerRepository customerRepository
            , IUnitOfWork unitOfWork)
        {
            this.consumeRecordRepository = consumeRecordRepository;
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        public PagedList<ConsumeRecord> GetConsumeRecordList(ConsumeRecordListRequest request)
        {
            return consumeRecordRepository.GetConsumeRecordList(request);
        }

        public string CreateCustomeConsume(ConsumeRequest request)
        {
            return consumeRecordRepository.CreateCustomeConsume(request);
        }

        public string RecallConsume(int consumeRecordID)
        {
            return consumeRecordRepository.RecallConsume(consumeRecordID);
        }
    }
}
