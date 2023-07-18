using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WxEpg.Cropper.Controllers
{
    public class SessionExpireHandle : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            if (httpContext.Session == null)
            {
                return;
            }
            var routeDic = new RouteValueDictionary(new { Controller = "Account", Action = "Login" });
            var session = httpContext.Session["USER"];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(routeDic);
            }
            if (httpContext.Session.IsNewSession)
            {
                var cookies = httpContext.Request.Headers["Cookie"];
                if (cookies != null && cookies.IndexOf("ASP.NET_SessionId", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    filterContext.Result = new RedirectToRouteResult(routeDic);
                }
            }
        }

    }
}