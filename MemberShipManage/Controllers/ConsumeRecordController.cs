using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
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
    }
}