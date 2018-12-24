﻿using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Service.Consume;
using MemberShipManage.Service.CustomerManage;
using System.Web.Http;
using Webdiyer.WebControls.Mvc;

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
        [HttpGet]
        public bool CheckCustomerExists(string userNo, string password)
        {
            return customerService.CheckCustomerExists(userNo, password);
        }

        /// <summary>
        /// Get customer info
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public Customer GetCustomer(string userNo)
        {
            return customerService.GetCustomer(userNo);
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
        public IPagedList<ConsumeRecord> GetConsumeRecordList(ConsumeRecordListRequest request)
        {
            return consumeRecordService.GetConsumeRecordList(request);
        }
    }
}