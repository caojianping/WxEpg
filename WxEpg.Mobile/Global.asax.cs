using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WxEpg.Mobile
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Utility.RootPath = Server.MapPath("~");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Logger.AppendLine(Context.Request.Url.ToString());
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            var path = Utility.LoggerPath + DateTime.Now.ToString("yyyyMMdd");
            Logger.AppendLine(path, Request.UserHostAddress + "," + Request.Url.ToString());
        }

    }
}