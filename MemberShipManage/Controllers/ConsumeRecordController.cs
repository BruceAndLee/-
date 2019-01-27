using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Models;
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
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult List(ConsumeRecordListRequest request)
        {
            var consumeRecordList = consumeRecordService.GetConsumeRecordList(request);
            var viewModel = Mapper.Map<ConsumeRecordListModel>(request);
            viewModel.ConsumeRecordList = consumeRecordList;
            return PartialView(viewModel);
        }

        [HttpGet]
        public IPagedList<ConsumeRecord> GetConsumeRecordList(ConsumeRecordListRequest request)
        {
            return consumeRecordService.GetConsumeRecordList(request);
        }

        [HttpPut]
        public JsonResult Recall(int id)
        {
            var errorCode = consumeRecordService.RecallConsume(id);
            if (!string.IsNullOrEmpty(errorCode))
            {
                return JsonResult(new APIBaseResponse(false, errorCode));
            }

            return SuccessJsonResult();
        }
    }
}