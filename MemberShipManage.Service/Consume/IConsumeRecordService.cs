using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Service.Consume
{
    public interface IConsumeRecordService
    {
        IPagedList<ConsumeRecord> GetConsumeRecordList(ConsumeRecordListRequest request);
        void CreateConsumeRecord(ConsumeRecord consumeRecord);
    }
}
