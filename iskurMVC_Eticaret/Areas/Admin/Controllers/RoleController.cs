using iskurMVC_Eticaret.Areas.Admin.Models.RoleModels;
using iskurMVC_Eticaret.Areas.Admin.Services;
using iskurMVC_Eticaret.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        RoleService roleService;
        UserService userService;
        public RoleController()
        {
            roleService = new RoleService();
        }
        // GET: Admin/Role
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Index(int id)
        {
            var userRoleList = roleService.GetUserRoleByUserID(id);
            return View(userRoleList);
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Insert(int id)
        {
            ViewBag.Roles = roleService.GetRoleByUserID(id).Select(x => new SelectListItem
            {
                Text = x.RoleName,
                Value = x.RoleID.ToString()
            }).ToList();

            userService = new UserService();
            var user = userService.GetUserByUserIDForView(id);

            InsertUserRole insertUserRole = new InsertUserRole();

            insertUserRole.UserID = user.UserID;
            insertUserRole.UserName = user.UserName;

            ViewBag.User = insertUserRole;

            return View(insertUserRole);
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Insert(InsertUserRole insertUserRole)
        {
            var user = (InsertUserRole)ViewBag.User;
            InsertUserRole userRole = new InsertUserRole()
            {
                UserID = insertUserRole.UserID,
                RoleID = insertUserRole.RoleID
            };
            roleService.InsertUserRoles(userRole);
            return RedirectToAction("Index", "User");
        }
    }
}