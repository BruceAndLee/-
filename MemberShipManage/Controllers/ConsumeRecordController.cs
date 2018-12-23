using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Service.Consume;
using System.Web.Mvc;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class ConsumeRecordController : BaseController
    {
        IConsumeRecordService consumeRecordService;
        public ConsumeRecordController(IConsumeRecordService consumeRecordService)
        {
            this.consumeRecordService = consumeRecordService;
        }

        [HttpGet]
        public IPagedList<ConsumeRecord> GetConsumeRecordList(string userNo, int pageIndex, int pageSize)
        {
            return consumeRecordService.GetConsumeRecordList(userNo, pageIndex, pageSize);
        }
    }
}