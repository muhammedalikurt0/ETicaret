using iskurMVC_Eticaret.Areas.Admin.Models.RoleModels;
using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace iskurMVC_Eticaret.Areas.Admin.Services
{
    public class RoleService
    {
        MVCE_TicaretDbContext dbContext;
        public RoleService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }

        // Kullanıcıda bulunmayan roller
        public List<RoleViewModel> GetRoleByUserID(int UserID)
        {
            var userRoleList = dbContext.UserRoles.Where(x => x.UserID == UserID).ToList();
            List<RoleViewModel> AllRoles = GetAllRoleViewModel();

            foreach (var item in userRoleList)
            {
                var newRole = AllRoles.Select(x => new RoleViewModel()
                {
                    RoleID = x.RoleID,
                    RoleName = x.RoleName
                }
                ).FirstOrDefault(x => x.RoleID == item.RoleID);

                if (newRole != null)
                {
                    var deletedRole = AllRoles.Find(x => x.RoleID == newRole.RoleID);
                    AllRoles.Remove(deletedRole);
                }

            }

            return AllRoles;
        }

        //Kullanıcıya göre roller
        public List<UserRoleViewModel> GetUserRoleByUserID(int UserID)
        {
            var UserRoleList = dbContext.UserRoles.Select(x => new UserRoleViewModel()
            {
                UserID = x.UserID,
                UserName = x.User.UserName,
                RoleID = x.RoleID,
                RoleName = x.Roles.RoleName
            }).Where(x => x.UserID == UserID).ToList();

            return UserRoleList;
        }

        //Tüm Roller
        public List<RoleViewModel> GetAllRoleViewModel()
        {
            var roleList = dbContext.Roles.Select(x => new RoleViewModel()
            {
                RoleID = x.RoleID,
                RoleName = x.RoleName
            }).ToList();

            return roleList;
        }

        public void InsertUserRoles(InsertUserRole selectedUserRole)
        {
            UserRoles userRoles = new UserRoles()
            {
                UserID = selectedUserRole.UserID,
                RoleID = selectedUserRole.RoleID
            };

            dbContext.UserRoles.Add(userRoles);
            dbContext.SaveChanges();

        }
    }
}