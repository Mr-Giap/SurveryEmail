using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ValueObjects;

namespace ServeyEmail.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = (OUsers)Session[CommonConstant.SESSION_ACCOUNT];
            if (session == null)
            {
                // Chưa đăng nhập => trang chủ khách hàng
                filterContext.Result = new RedirectToRouteResult(new
                        RouteValueDictionary(new
                        {
                            controller = "Logins",
                            action = "Login"
                        }));
            }
            base.OnActionExecuting(filterContext);
        }

    }
}