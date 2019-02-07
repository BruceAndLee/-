using MemberShipManage.Domain;
using MemberShipManage.Infrastructure;
using MemberShipManage.Infrastructure.UnitOfWork;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.Statistics
{
    public class StatisticsRepository : BaseRepository<object>, IStatisticsRepository
    {
        public StatisticsRepository(IUnitOfWork dbcontext)
            : base(dbcontext)
        {

        }

        public UP_GetDailyReport_Result GetDailyReport(DateTime? date)
        {
            var sqlScript = DBScriptManager.GetScript(this.GetType(), "GetDailyReport");
            var paramDate = new SqlParameter("@StatisticDate", SqlDbType.DateTime);
            if (date.HasValue)
            {
                paramDate.Value = date;
            }
            else
            {
                paramDate.Value = DBNull.Value;
            }

            var result = ExecuteSqlQuery<UP_GetDailyReport_Result>(sqlScript, new SqlParameter[] { paramDate });
            return result != null ? result.FirstOrDefault() : null;
        }
    }
}
