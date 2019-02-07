using MemberShipManage.Domain;
using MemberShipManage.Domain.Entity;
using PersonalSite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Repository.Statistics
{
    public interface IStatisticsRepository : IRepository<object>
    {
        UP_GetDailyReport_Result GetDailyReport(DateTime? date);
    }
}
