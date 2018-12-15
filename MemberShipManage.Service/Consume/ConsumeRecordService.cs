using MemberShipManage.Repository.Consume;

namespace MemberShipManage.Service.Consume
{
    public class ConsumeRecordService: IConsumeRecordService
    {
        IConsumeRecordRepository consumeRecordRepository;
        public ConsumeRecordService(IConsumeRecordRepository consumeRecordRepository)
        {
            this.consumeRecordRepository = consumeRecordRepository;
        }
    }
}
