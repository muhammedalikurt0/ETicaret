using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Attributes
{
    public class ControllerAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var attribute = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(ControllerAuthorizeAttribute), false).FirstOrDefault();

            var roles = ((AuthorizeAttribute)attribute).Roles.Split(',');
            try
            {
                var userRole = HttpContext.Current.Session["Role"].ToString();
                if (!roles.Any(x => x == userRole))
                {
                    filterContext.Result = new RedirectResult("/Log/Login");
                }
              
            }
            catch
            {
                filterContext.Result = new RedirectResult("/Log/Login");
            }



        }

    }
}