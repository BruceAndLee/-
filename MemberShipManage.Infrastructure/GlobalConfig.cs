using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Infrastructure
{
    public class GlobalConfig
    {
        #region webconfig
        public static readonly string MessageResourceFolder = ConfigurationManager.AppSettings["MessageResourceFolder"];
        public static readonly int DefaultPageSize = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPageSize"]);
        #endregion

        #region API

        public static readonly string AppID = ConfigurationManager.AppSettings["appID"];

        #endregion
    }
}
