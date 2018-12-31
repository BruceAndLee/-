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
using MemberShipManage.Infrastructure;
using System.Data.SqlClient;
using System.Data;

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
            return new PagedList<ConsumeRecord>(query, request.PageIndex - 1, request.PageSize);
        }

        public string CreateCustomeConsume(ConsumeRequest request)
        {
            var sqlScript = DBScriptManager.GetScript(this.GetType(), "CreateCustomeConsume");

            var paramErrorMsg = new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 1000);
            paramErrorMsg.Direction = ParameterDirection.Output;

            var paramCustomerID = new SqlParameter("@CustomerID", SqlDbType.Int);
            paramCustomerID.Value = request.CustomerID;

            var paramAmount = new SqlParameter("@Amount", SqlDbType.Decimal);
            paramAmount.Value = request.Amount;

            var paramDetail = new SqlParameter("@Detail", SqlDbType.NVarChar, 1000);
            paramDetail.Value = request.Detail ?? string.Empty;

            var paramUserID = new SqlParameter("@UserID", SqlDbType.VarChar, 25);
            paramUserID.Value = request.UserID;

            var paramDiscountRatio = new SqlParameter("@DiscountRatio", SqlDbType.Decimal);
            paramDiscountRatio.Value = request.DiscountRatio;

            var paramKickbackRatio = new SqlParameter("@KickbackRatio", SqlDbType.Decimal);
            paramKickbackRatio.Value = request.KickbackRatio;

            ExecuteSqlCommand(sqlScript,
                new SqlParameter[]
                {
                    paramCustomerID,
                    paramAmount,
                    paramDetail,
                    paramUserID,
                    paramDiscountRatio,
                    paramKickbackRatio,
                    paramErrorMsg
                });

            return Convert.ToString(paramErrorMsg.Value);
        }
    }
}
