using iskurMVC_Eticaret.Services;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iskurMVC_Eticaret.Attributes;

namespace iskurMVC_Eticaret.Controllers
{
    [ControllerAuthorize(Roles = "User")]
    public class UsersController : Controller
    {
        UserService userService;
        public UsersController()
        {
            userService = new UserService();
        }
        [HttpGet]
        public ActionResult Profil()
        {
            var user = (LoginModel)Session["User"];
            var userID = user.UserID;
            var selectedUser = userService.GetUserByUserID(userID);
            return View(selectedUser);
        }
        [HttpPost]
        public ActionResult Profil(UserModel userModel)
        {
            userService.UpdateUser(userModel);
            return RedirectToAction("Index", "Main");
        }

    }
}