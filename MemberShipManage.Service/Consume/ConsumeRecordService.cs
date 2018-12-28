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
        }

        public IPagedList<ConsumeRecord> GetConsumeRecordList(ConsumeRecordListRequest request)
        {
            return consumeRecordRepository.GetConsumeRecordList(request);
        }

        public void CreateConsumeRecord(ConsumeRecord consumeRecord) 
        {
            consumeRecordRepository.Insert(consumeRecord);
            unitOfWork.Commit();
        }
    }
}
