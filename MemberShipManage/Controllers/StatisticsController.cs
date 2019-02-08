using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure;
using MemberShipManage.Infrastructure.Base;
using MemberShipManage.Infrastructure.Filter;
using MemberShipManage.Service.Statistics;
using MemberShipManage.Service.System;
using MemberShipManage.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemberShipManage.Controllers
{
    [UserSessionFilter]
    public class StatisticsController : BaseController
    {
        IStatisticsService statisticsService;
        ISystemService systemService;
        public StatisticsController(
            IStatisticsService statisticsService
            , ISystemService systemService)
        {
            this.statisticsService = statisticsService;
            this.systemService = systemService;
        }

        public ViewResult DailyReport(string date)
        {
            DateTime convertDate = DateTime.MinValue;
            DateTime.TryParse(date, out convertDate);
            var dailyReport = statisticsService.GetDailyReport(convertDate == DateTime.MinValue ? (DateTime?)null : convertDate);

            var sysConfig = systemService.GetSystemConfigs();
            var discountRatioConfig = sysConfig.Find(s => s.ConfigKey == SystemConfigTypes.MemberDiscountRatio.ToString());
            var discount = Convert.ToDecimal(Cryptor.Decrypt(discountRatioConfig.ConfigValue));
            dailyReport.TotalDiscount = Math.Round(Math.Round(dailyReport.TotalSales / discount, 0) * (1 - discount), 0);
            return View(dailyReport);
        }
    }
}