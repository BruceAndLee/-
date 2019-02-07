using MemberShipManage.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.Statistics
{
    public interface IStatisticsService
    {
        DailyReportEntity GetDailyReport(DateTime? date);
    }
}
