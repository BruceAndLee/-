using MemberShipManage.Domain.Entity;
using MemberShipManage.Infrastructure.Serialization;
using MemberShipManage.Repository.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Service.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        IStatisticsRepository statisticRepository;
        public StatisticsService(IStatisticsRepository statisticRepository)
        {
            this.statisticRepository = statisticRepository;
        }

        public DailyReportEntity GetDailyReport(DateTime? date)
        {
            var result = this.statisticRepository.GetDailyReport(date);
            if (result != null)
            {
                return new DailyReportEntity
                {
                    TotalRebate = result.TotalRebate,
                    TotalSales = result.TotalSales,
                    TotalRecharge = result.TotalRecharge,
                    RebateList = result.RebateList != null ? XmlSerialization.Deserialize<List<AmountEntity>>(result.RebateList, "RebateList") : null,
                    SalesList = result.SalesList != null ? XmlSerialization.Deserialize<List<AmountEntity>>(result.SalesList, "SalesList") : null
                };
            }

            return new DailyReportEntity { TotalRebate = 0, TotalSales = 0 };
        }
    }
}
