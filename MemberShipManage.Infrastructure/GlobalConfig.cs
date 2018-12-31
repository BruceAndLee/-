﻿using System;
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
        public static readonly string DbScriptXmlPath = ConfigurationManager.AppSettings["DbScriptXmlPath"];
        public static readonly decimal DiscountRatio = Convert.ToDecimal(ConfigurationManager.AppSettings["DiscountRatio"]);
        public static readonly decimal KickbackRatio = Convert.ToDecimal(ConfigurationManager.AppSettings["KickbackRatio"]);
        #endregion

        #region API

        public static readonly string AppID = ConfigurationManager.AppSettings["appID"];

        #endregion
    }
}
