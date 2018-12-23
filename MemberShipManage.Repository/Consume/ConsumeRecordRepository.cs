﻿using MemberShipManage.Domain;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace MemberShipManage.Repository.Consume
{
    public class ConsumeRecordRepository : BaseRepository<ConsumeRecord>, IConsumeRecordRepository
    {
        public ConsumeRecordRepository(IUnitOfWork dbcontext)
              : base(dbcontext)
        {

        }

        /// <summary>
        /// Get customer consume records
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IPagedList<ConsumeRecord> GetConsumeRecordList(int customerID, int pageIndex, int pageSize)
        {
            var query = dbSet.Where(d => d.CustomerID == customerID);
            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<ConsumeRecord>(query, pageIndex, pageSize);
        }
    }
}
