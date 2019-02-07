using MemberShipManage.Infrastructure.Serialization;
using MemberShipManage.Utility;
using System;
using System.Linq;

namespace MemberShipManage.Infrastructure.Config
{
    public static class RatioConfigHelper
    {
        private static RatioConfigCollection _RatioConfigCollection;
        private static RatioConfigCollection GetRatioConfigCollection()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\RatioConfig.xml";
            try
            {
                if (_RatioConfigCollection == null)
                {
                    _RatioConfigCollection = XmlSerialization.DeserializeByFile<RatioConfigCollection>(path);
                }

                return _RatioConfigCollection;
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.StackTrace);
                throw;
            }
        }

        public static RatioConfig GetRatioConfig(string name)
        {
            var _RatioConfigCollection = GetRatioConfigCollection();
            if (_RatioConfigCollection != null
                && _RatioConfigCollection.RatioConfigs != null
                && _RatioConfigCollection.RatioConfigs.Length > 0)
            {
                var config = _RatioConfigCollection.RatioConfigs.FirstOrDefault(f => f.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
                return config;
            }

            return null;
        }
    }
}
