using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Infrastructure.UnitOfWork;
using MemberShipManage.Models;
using MemberShipManage.Service.CustomerManage;
using MemberShipManage.Service.Recharge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class RechargeController : BaseController
    {
        IRechargeRecordService rechargeRecordService;
        ICustomerAmountService customerAmountService;
        ICustomerService customerService;
        public RechargeController(
            IRechargeRecordService rechargeRecordService
            , ICustomerAmountService customerAmountService
            , ICustomerService customerService)
        {
            this.rechargeRecordService = rechargeRecordService;
            this.customerAmountService = customerAmountService;
            this.customerService = customerService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult List(RechargeListRequest request)
        {
            var rechargeRecordList = rechargeRecordService.GetRechargeRecordList(request);
            var viewModel = Mapper.Map<RechargeListModel>(request);
            viewModel.RechargeRecordList = rechargeRecordList;
            return PartialView(viewModel);
        }

        [HttpPost]
        public JsonResult Create(RechargeRecord rechargeRecord)
        {
            var customer = customerService.GetCustomer(rechargeRecord.CustomerID);
            if (customer == null || !customer.Status)
            {
                return JsonResult(new APIBaseResponse(false, "CM_002"));
            }

            if (rechargeRecord.Amount <= 0)
            {
                return JsonResult(new APIBaseResponse(false, "CM_003"));
            }

            var customerAmount = new CustomerAmount
            {
                CustomerID = rechargeRecord.CustomerID,
                Amount = rechargeRecord.Amount,
                InUser = rechargeRecord.InUser
            };

            customerAmountService.CreateCustomerAmount(customerAmount);
            rechargeRecordService.CreateRechargeRecord(rechargeRecord);

            return SuccessJsonResult();
        }

        [HttpPut]
        public JsonResult Recall(int id)
        {
            var errorCode = rechargeRecordService.RecallRecharge(id);
            if (!string.IsNullOrEmpty(errorCode))
            {
                return JsonResult(new APIBaseResponse(false, errorCode));
            }

            return SuccessJsonResult();
        }
    }
}