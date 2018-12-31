using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MemberShipManage.Infrastructure.Serialization
{
    public class XmlSerialization
    {
        public static T Deserialize<T>(string path) where T : class, new()
        {
            XmlReader xmlReader = XmlReader.Create(path);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            object deSerializeObj = xmlSer.Deserialize(xmlReader);
            xmlReader.Close();
            return deSerializeObj as T;
        }
    }
}
