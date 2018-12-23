using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System.Linq;
using Webdiyer.WebControls.Mvc;

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
            if (request.CustomerID.HasValue)
            {
                query = query.Where(q => q.CustomerID == request.CustomerID);
            }

            if (!string.IsNullOrEmpty(request.UserNo))
            {
                query = query.Where(q => q.Customer.UserNo.Contains(request.UserNo));
            }

            if (!string.IsNullOrEmpty(request.Name))
            {
                query = query.Where(q => q.Customer.Name.Contains(request.Name));
            }

            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<RechargeRecord>(query, request.PageIndex, request.PageSize);
        }
    }
}
