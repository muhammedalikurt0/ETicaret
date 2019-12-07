using iskurMVC_Eticaret.Areas.Admin.Models;
using iskurMVC_Eticaret.Areas.Admin.Services;
using iskurMVC_Eticaret.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        UserService userService;
        public AccountController()
        {
            userService = new UserService();
        }
        // GET: Admin/Account
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Admin"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }
        }
        [HttpPost]
        public ActionResult Login(ControlUserNamePasswordModel controlUser)
        {

            var enteredUser = userService.GetSelectedUser(controlUser);
            if (enteredUser != null)
            {
                var role = userService.GetUserRoles(enteredUser.UserID);
                Session["Role"] = role;
                Session["Admin"] = enteredUser;
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Exit()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

    }



}