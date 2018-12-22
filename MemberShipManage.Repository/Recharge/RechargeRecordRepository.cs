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

        public IPagedList<RechargeRecord> GetRechargeRecordList(int? customerID, int pageIndex, int pageSize)
        {
            IQueryable<RechargeRecord> query = this.dbSet;
            if (customerID.HasValue)
            {
                query = query.Where(q => q.CustomerID == customerID);
            }

            return new PagedList<RechargeRecord>(query, pageIndex, pageSize);
        }

        public void CreateRechargeRecord(RechargeRecord rechargeRecord)
        {
            var rechargeRecordDb = dbSet.FirstOrDefault(d => d.CustomerID == rechargeRecord.CustomerID);
            if (rechargeRecordDb != null)
            {
                rechargeRecordDb.Amount = rechargeRecord.Amount;
                Update(rechargeRecordDb);
            }
            else
            {
                Insert(rechargeRecord);
            }
        }
    }
}
