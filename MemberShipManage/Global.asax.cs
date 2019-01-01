using MemberShipManage.Framework;
using MemberShipManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Reflection;
using MemberShipManage.Models;
using MemberShipManage.Utility;

namespace MemberShipManage
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            if (Singleton<IAppStartManager>.Instance == null)
            {
                Singleton<IAppStartManager>.Instance = new AppStartManager();
            }

            Singleton<IAppStartManager>.Instance.Initialize(Assembly.GetExecutingAssembly());
            AutoMapperManager.InitMapperCollection();
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.Error(e.ToString());
        }
    }
}
