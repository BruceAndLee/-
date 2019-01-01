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
        [Route("exist")]
        public bool CheckCustomerExists(string userNo, string password)
        {
            return customerService.CheckCustomerExists(userNo, password);
        }

        /// <summary>
        /// Get customer info
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpGet]
        [Route("{userno}")]
        public CustomerEntity GetCustomer(string userNo)
        {
            var customer = customerService.GetCustomer(userNo);
            return customer != null ? Mapper.Map<CustomerEntity>(customer) : null;
        }

        /// <summary>
        /// Get customer banlance
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        //[Authorize]
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
        //[Authorize]
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