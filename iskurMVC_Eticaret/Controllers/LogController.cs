using iskurMVC_Eticaret.Models;
using iskurMVC_Eticaret.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Controllers
{
    public class LogController : Controller
    {
        UserService userService;
        public LogController()
        {
            userService = new UserService();
        }
        // GET: Log
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateAccountModel accountModel)
        {
            var user = userService.InsertUser(accountModel);
            if (user != null)
            {
                LoginModel loginModel = new LoginModel()
                {
                    UserID = user.UserID,
                    UserName = user.UserName,
                    Password = user.Password
                };
                Session["Role"] = "User";
                Session["User"] = loginModel;
                return RedirectToAction("Index", "Main");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var user = userService.UserLogin(loginModel);
            if (user != null)
            {
                Session["User"] = user;
                Session["Role"] = "User";
                return RedirectToAction("Index", "Main");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Exit()
        {
            Session.Remove("User");
            Session.Remove("Role");
            return RedirectToAction("Index", "Main");
        }
    }
}