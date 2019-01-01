using AutoMapper;
using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Service.Consume;
using MemberShipManage.Service.CustomerManage;
using System.Web.Http;
using Webdiyer.WebControls.Mvc;
using System.Linq;
using System.Collections.Generic;

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
        public CustomerController(
            ICustomerService customerService
            , IConsumeRecordService consumeRecordService)
        {
            this.customerService = customerService;
            this.consumeRecordService = consumeRecordService;
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
    }
}