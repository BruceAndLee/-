using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MemberShipManage.Infrastructure.Serialization
{
    public class XmlSerialization
    {
        public static T DeserializeByFile<T>(string path) where T : class, new()
        {
            XmlReader xmlReader = XmlReader.Create(path);
            XmlSerializer xmlSer = new XmlSerializer(typeof(T));
            object deSerializeObj = xmlSer.Deserialize(xmlReader);
            xmlReader.Close();
            return deSerializeObj as T;
        }

        public static T Deserialize<T>(string xml, string root) where T : class, new()
        {
            using (StringReader streamReader = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(typeof(T), new XmlRootAttribute(root));
                return (T)xmldes.Deserialize(streamReader);
            }
        }

        public static string SerializeToXml<T>(T entity) where T : class, new()
        {
            if (entity == null) return null;

            string xmlBody;
            var xml = new XmlSerializer(entity.GetType());
            var stream = new MemoryStream();
            var nameSpace = new XmlSerializerNamespaces();
            nameSpace.Add(string.Empty, string.Empty);
            xml.Serialize(stream, entity, nameSpace);
            stream.Position = 0;
            using (var reader = new StreamReader(stream))
            {
                xmlBody = reader.ReadToEnd();
                stream.Close();
            }
            return xmlBody;
        }
    }
}
