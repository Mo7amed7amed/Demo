using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.My_Filters
{
    public class MyAuthorizeFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Boolean? b = (Boolean?)filterContext.HttpContext.Session["isAuthinticated"];
            if (b == null || b.Value == false)
                filterContext.Result = new RedirectResult("/account/login?returnurl="+filterContext.HttpContext.Request.Url);
        }

    }
}