using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Service.Consume;
using MemberShipManage.Service.CustomerManage;
using System.Web.Http;
using Webdiyer.WebControls.Mvc;
using System.Linq;
using System.Collections.Generic;
using MemberShipManage.Service.Recharge;

namespace MemberShipManage.WebAPI.Controllers
{
    /// <summary>
    /// Customer CRUD API
    /// </summary>
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        ICustomerService customerService;
        IConsumeRecordService consumeRecordService;
        IRechargeRecordService rechargeRecordService;
        public CustomerController(
            ICustomerService customerService
            , IConsumeRecordService consumeRecordService
            , IRechargeRecordService rechargeRecordService)
        {
            this.customerService = customerService;
            this.consumeRecordService = consumeRecordService;
            this.rechargeRecordService = rechargeRecordService;
        }

        /// <summary>
        /// Check customer if exist
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet()]
        [Route]
        public CustomerEntity GetCustomer(string userNo, string password)
        {
            var customer = customerService.GetCustomerInfo(userNo, password);
            if (customer == null)
            {
                return null;
            }

            var amount = customer.CustomerAmount != null && customer.CustomerAmount.Count > 0 ? customer.CustomerAmount.First().Amount : 0;
            var customerEntity = Mapper.Map<CustomerEntity>(customer);
            customerEntity.Amount = amount;
            return customerEntity;
        }

        /// <summary>
        /// Get customer banlance
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("balance")]
        public decimal GetCustomerBalance(string userNo)
        {
            return customerService.GetCustomerBalance(userNo);
        }

        /// <summary>
        /// Get Customer consume record
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("consume")]
        public IPagedList<ConsumeRecordEntity> GetConsumeRecordList([FromUri]ConsumeRecordListRequest request)
        {
            var consumeRecords = consumeRecordService.GetConsumeRecordList(request);
            var consumeRecordList = consumeRecords.ToList();
            var convertConsumeRecordList = Mapper.Map<List<ConsumeRecordEntity>>(consumeRecordList);
            return new PagedList<ConsumeRecordEntity>(convertConsumeRecordList, request.PageIndex, request.PageSize, consumeRecords.TotalItemCount);
        }

        /// <summary>
        /// Get Customer recharge record
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
  
        [HttpGet]
        [Route("recharge")]
        public IPagedList<RechargeRecordEntity> GetRechargeRecordList([FromUri]RechargeListRequest request)
        {
            var rechargeRecords = rechargeRecordService.GetRechargeRecordList(request);
            var rechargeRecordList = rechargeRecords.ToList();
            var convertRechargeRecordList = Mapper.Map<List<RechargeRecordEntity>>(rechargeRecordList);
            return new PagedList<RechargeRecordEntity>(convertRechargeRecordList, request.PageIndex, request.PageSize, rechargeRecords.TotalItemCount);
        }
    }
}