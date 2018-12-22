using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Infrastructure.UnitOfWork;
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

        [HttpPost]
        public JsonResult Create(RechargeRecord rechargeRecord)
        {
            var customer = customerService.GetCustomer(rechargeRecord.CustomerID);
            if (customer == null)
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
                Amount = rechargeRecord.Amount
            };

            customerAmountService.CreateCustomerAmount(customerAmount);
            rechargeRecordService.CreateRechargeRecord(rechargeRecord);

            return SuccessJsonResult();
        }
    }
}