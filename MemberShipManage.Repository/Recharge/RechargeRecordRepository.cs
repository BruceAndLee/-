using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System.Linq;
using Webdiyer.WebControls.Mvc;
using MemberShipManage.Infrastructure.Extension;

namespace MemberShipManage.Repository.Recharge
{
    public class RechargeRecordRepository : BaseRepository<RechargeRecord>, IRechargeRecordRepository
    {
        public RechargeRecordRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        { }

        public IPagedList<RechargeRecord> GetRechargeRecordList(RechargeListRequest request)
        {
            IQueryable<RechargeRecord> query = this.dbSet;
            query = query.WhereIf(request.CustomerID.HasValue, q => q.CustomerID == request.CustomerID);
            query = query.WhereIf(!string.IsNullOrEmpty(request.UserNo), q => q.Customer.UserNo.Contains(request.UserNo));
            query = query.WhereIf(!string.IsNullOrEmpty(request.Name), q => q.Customer.Name.Contains(request.Name));
            query = query.WhereIf(request.StartDate.HasValue, q => q.InDate >= request.StartDate);
            query = query.WhereIf(request.EndDate.HasValue, q => q.InDate <= request.EndDate);
            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<RechargeRecord>(query, request.PageIndex - 1, request.PageSize);
        }
    }
}
