using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System.Linq;
using Webdiyer.WebControls.Mvc;
using MemberShipManage.Infrastructure.Extension;
using MemberShipManage.Infrastructure;
using System.Data.SqlClient;
using System.Data;
using System;

namespace MemberShipManage.Repository.Recharge
{
    public class RechargeRecordRepository : BaseRepository<RechargeRecord>, IRechargeRecordRepository
    {
        public RechargeRecordRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        { }

        public PagedList<RechargeRecord> GetRechargeRecordList(RechargeListRequest request)
        {
            IQueryable<RechargeRecord> query = this.dbSet.Where(d => d.Status && d.Customer.Status);
            query = query.WhereIf(request.CustomerID.HasValue, q => q.CustomerID == request.CustomerID);
            query = query.WhereIf(!string.IsNullOrEmpty(request.UserNo), q => q.Customer.UserNo.Contains(request.UserNo));
            query = query.WhereIf(!string.IsNullOrEmpty(request.Name), q => q.Customer.Name.Contains(request.Name));
            query = query.WhereIf(request.StartDate.HasValue, q => q.InDate >= request.StartDate);
            query = query.WhereIf(request.EndDate.HasValue, q => q.InDate <= request.EndDate);
            query = query.OrderByDescending(q => q.InDate);
            return new PagedList<RechargeRecord>(query, request.PageIndex, request.PageSize);
        }

        public string RecallRecharge(int rechargeRecordID)
        {
            var sqlScript = DBScriptManager.GetScript(this.GetType(), "RecallRechargeRecord");

            var paramErrorMsg = new SqlParameter("@ErrorMessageCode", SqlDbType.NVarChar, 500);
            paramErrorMsg.Direction = ParameterDirection.Output;

            var paramRechargeRecordID = new SqlParameter("@RechargeRecordID", SqlDbType.Int);
            paramRechargeRecordID.Value = rechargeRecordID;

            ExecuteSqlCommand(sqlScript,
               new SqlParameter[]
               {
                    paramRechargeRecordID,
                    paramErrorMsg
               });

            return Convert.ToString(paramErrorMsg.Value);
        }
    }
}
