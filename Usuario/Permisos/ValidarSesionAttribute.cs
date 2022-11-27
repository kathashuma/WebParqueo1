using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebParqueo.Permisos
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Sesion/LoginPage");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}