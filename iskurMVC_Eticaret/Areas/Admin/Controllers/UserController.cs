using iskurMVC_Eticaret.Areas.Admin.Models.UserModels;
using iskurMVC_Eticaret.Areas.Admin.Services;
using iskurMVC_Eticaret.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        UserService userService;
        RoleService roleService;
        public UserController()
        {
            userService = new UserService();
        }
        // GET: Admin/User
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userList = userService.GetAllUsers();
            return View(userList);
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Insert()
        {
            roleService = new RoleService();
            ViewBag.Roles = roleService.GetAllRoleViewModel().Select(x => new SelectListItem
            {
                Text = x.RoleName,
                Value = x.RoleID.ToString()
            }).ToList();
            return View();
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Insert(InsertUserModel insertUserModel)
        {
            userService.InsertUserAndUserRole(insertUserModel);
            return RedirectToAction("Index");
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            UpdateUserModel updateUser = userService.GetUserByUserIDForUpdate(id);
            return View(updateUser);
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(UpdateUserModel updateUserModel)
        {
            userService.UpdateUser(updateUserModel);
            return RedirectToAction("Index");
        }
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}