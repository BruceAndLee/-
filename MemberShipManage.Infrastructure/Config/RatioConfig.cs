using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MemberShipManage.Infrastructure.Config
{
    [XmlRoot("RatioConfigCollection")]
    public class RatioConfigCollection
    {
        [XmlElement("RatioConfig")]
        public RatioConfig[] RatioConfigs;
    }

    public class RatioConfig
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlAttribute("value")]
        public decimal value;
    }
}
