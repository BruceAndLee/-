using MemberShipManage.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MemberShipManage.Infrastructure
{
    public class MessageResourceBuilder
    {
        private static Dictionary<string, string> messages;

        public static string GetMessageResource(string resourceID)
        {
            if (messages == null || messages.Count == 0)
            {
                messages = GetAllMessageResource();
            }

            if (!messages.ContainsKey(resourceID))
            {
                throw new Exception(string.Concat("ResourceID:", resourceID, " doesn't exist in message resource file."));
            }

            return messages[resourceID];
        }

        private static Dictionary<string, string> GetAllMessageResource()
        {
            Dictionary<string, string> messageResources = new Dictionary<string, string>();
            string baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            string messageFolder = GlobalConfig.MessageResourceFolder;
            string messageResourceFolder = Path.Combine(baseFolder, messageFolder);

            if (!Directory.Exists(messageResourceFolder))
            {
                LogHelper.Error(string.Concat(MethodBase.GetCurrentMethod().Name, ":", "MessageResource Folder does'nt exist!"));
                return null;
            }

            string[] resourceFiles = Directory.GetFiles(messageResourceFolder, "*.xml", SearchOption.AllDirectories);
            if (resourceFiles.Length == 0)
            {
                LogHelper.Error(string.Concat(MethodBase.GetCurrentMethod().Name, ":", "MessageResource files don't exist!"));
                return null;
            }

            foreach (var resourceFile in resourceFiles)
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(resourceFile);

                XmlElement root = xmlDocument.DocumentElement;
                XmlNodeList nodeList = root.SelectNodes("/MessageResources/Message");
                foreach (XmlNode node in nodeList)
                {
                    messageResources.Add(node.Attributes["ResourceID"].Value, node.InnerText);
                }
            }

            return messageResources;
        }
    }
}
