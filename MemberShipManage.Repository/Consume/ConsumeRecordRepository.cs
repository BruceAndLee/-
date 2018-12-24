using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using MemberShipManage.Infrastructure.Extension;

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
        public IPagedList<ConsumeRecord> GetConsumeRecordList(ConsumeRecordListRequest request)
        {
            IQueryable<ConsumeRecord> query = dbSet;
            query = query.WhereIf(request.CustomerID.HasValue, q => q.CustomerID == request.CustomerID);
            query = query.WhereIf(!string.IsNullOrEmpty(request.UserNo), q => q.Customer.UserNo.Contains(request.UserNo));
            query = query.WhereIf(!string.IsNullOrEmpty(request.Name), q => q.Customer.Name.Contains(request.Name));
            query = query.WhereIf(request.StartDate.HasValue, q => q.InDate >= request.StartDate);
            query = query.WhereIf(request.EndDate.HasValue, q => q.InDate <= request.EndDate);
            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<ConsumeRecord>(query, request.PageIndex, request.PageSize);
        }
    }
}
