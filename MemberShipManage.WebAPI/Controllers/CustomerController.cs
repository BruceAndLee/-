﻿using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.Pagination;
using MemberShipManage.Infrastructure.RestAPI;
using MemberShipManage.Service.Consume;
using MemberShipManage.Service.CustomerManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

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
        public async Task<bool> CheckCustomerExists(string userNo, string password)
        {
            return await customerService.CheckCustomerExists(userNo, password);
        }

        /// <summary>
        /// Get customer info
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<Customer> GetCustomer(string userNo)
        {
            return await customerService.GetCustomer(userNo);
        }

        /// <summary>
        /// Get customer banlance
        /// </summary>
        /// <param name="userNo"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("balance")]
        public async Task<decimal> GetCustomerBalance(string userNo)
        {
            return await customerService.GetCustomerBalance(userNo);
        }

        /// <summary>
        /// Get Customer consume record
        /// </summary>
        /// <param name="userNo"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("consume")]
        public async Task<IPagedList<ConsumeRecord>> GetConsumeRecordList(string userNo, int pageIndex, int pageSize)
        {
            return await consumeRecordService.GetConsumeRecordList(userNo, pageIndex, pageSize);
        }
    }
}