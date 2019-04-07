using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MemberShipManage.Domain.Entity
{
    public class DailyReportEntity
    {
        public decimal TotalRecharge { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalRebate { get; set; }
        public decimal TotalDiscount { get; set; }
        public List<AmountEntity> SalesList { get; set; }
        public List<AmountEntity> RebateList { get; set; }
    }

    [XmlRoot("AmountEntity")]
    public class AmountEntity
    {
        [XmlElement("UserNo")]
        public string UserNo { get; set; }

        [XmlElement("CustomerName")]
        public string CustomerName { get; set; }

        [XmlElement("Amount")]
        public decimal Amount { get; set; }

        [XmlElement("InDate")]
        public DateTime? InDate { get; set; }

        public string UserInfo
        {
            get
            {
                return string.Concat("(", UserNo, ") ", CustomerName);
            }
        }
    }
}
