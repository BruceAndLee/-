using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemberShipManage.Utility
{
    public class LogHelper
    {
        private static readonly ILog LogInfo = LogManager.GetLogger("LogInfo");
        private static readonly ILog LogError = LogManager.GetLogger("LogError");
        private static readonly ILog LogMonitor = LogManager.GetLogger("LogMonitor");

        /// <summary>
        /// 记录Error日志
        /// </summary>
        /// <param name="errorMsg"></param>
        /// <param name="ex"></param>
        public static void Error(string errorMsg, Exception ex = null)
        {
            if (ex != null)
            {
                LogError.Error(errorMsg, ex);
            }
            else
            {
                LogError.Error(errorMsg);
            }
        }

        /// <summary>
        /// 记录Info日志
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="ex"></param>
        public static void Info(string msg, Exception ex = null)
        {
            if (ex != null)
            {
                LogInfo.Info(msg, ex);
            }
            else
            {
                LogInfo.Info(msg);
            }
        }

        /// <summary>
        /// 记录Monitor日志
        /// </summary>
        /// <param name="msg"></param>
        public static void Monitor(string msg)
        {
            LogMonitor.Info(msg);
        }
    }
}
