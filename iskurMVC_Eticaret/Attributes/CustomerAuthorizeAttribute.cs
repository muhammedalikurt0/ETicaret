using iskurMVC_Eticaret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Attributes
{
    public class CustomerAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var attribute = filterContext.ActionDescriptor.GetCustomAttributes(typeof(CustomerAuthorizeAttribute), false).FirstOrDefault();

            var roles = ((AuthorizeAttribute)attribute).Roles.Split(',');

            var userRoles = (List<UserRoles>)HttpContext.Current.Session["Role"];

            if (userRoles == null)
            {
                filterContext.Result = new RedirectResult("/Admin/Account/Login");
            }
            else
            {
                bool situation = false;
                foreach (var item in userRoles)
                {
                    if (roles.Any(x => x == item.Roles.RoleName))
                    {
                        situation = true;
                    }
                }

                if (situation == false)
                {
                    filterContext.Result = new RedirectResult("/Admin/Account/Login");
                }
            }

        }


    }
}
