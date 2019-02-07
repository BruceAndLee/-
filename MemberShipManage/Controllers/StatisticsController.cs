using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Service.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class StatisticsController : BaseController
    {
        IStatisticsService statisticsService;
        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        public DailyReportEntity GetDailyReport(DateTime? date)
        {
            return statisticsService.GetDailyReport(date);
        }
    }
}