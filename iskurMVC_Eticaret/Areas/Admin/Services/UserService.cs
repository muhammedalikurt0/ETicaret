using iskurMVC_Eticaret.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iskurMVC_Eticaret.Areas.Admin.Models;
using iskurMVC_Eticaret.Data.Entities;
using iskurMVC_Eticaret.Areas.Admin.Models.UserModels;
using iskurMVC_Eticaret.Areas.Admin.Models.RoleModels;

namespace iskurMVC_Eticaret.Areas.Admin.Services
{
    public class UserService
    {
        MVCE_TicaretDbContext dbContext;
        public UserService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }

        public EnterUserLoginModel GetSelectedUser(ControlUserNamePasswordModel controlUser)
        {
            EnterUserLoginModel enteredUser = new EnterUserLoginModel();
            var userList = dbContext.Users.FirstOrDefault(x => x.Password == controlUser.Password && x.UserName == controlUser.UserName);
            if (userList != null)
            {
                enteredUser.UserID = userList.UserID;
                enteredUser.UserName = userList.UserName;
                enteredUser.Password = userList.Password;
                return enteredUser;
            }
            else
            {
                return null;
            }
        }

        public List<UserRoles> GetUserRoles(int UserID)
        {
            var userRole = dbContext.UserRoles.Where(x => x.UserID == UserID).ToList();
            return userRole;
        }

        public List<UserViewModel> GetAllUsers()
        {
            var userList = dbContext.Users.Select(x => new UserViewModel()
            {
                UserID = x.UserID,
                UserName = x.UserName,
                Phone = x.Phone,
                EPosta = x.Email
            }).ToList();

            return userList;
        }

        public UserViewModel GetUserByUserIDForView(int userID)
        {
            var user = dbContext.Users.Where(x => x.UserID == userID).Select(x => new UserViewModel()
            {
                UserID = x.UserID,
                UserName = x.UserName
            }).FirstOrDefault();

            return user;

        }

        public int InsertUsert(InsertUserModel insertUserModel)
        {
            User user = new User()
            {
                UserName = insertUserModel.UserName,
                Password = insertUserModel.Password,
                Phone = insertUserModel.Phone,
                Email = insertUserModel.Email,
            };
            var insertedUser = dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return insertedUser.UserID;
        }

        public void InsertUserAndUserRole(InsertUserModel insertUserModel)
        {
            RoleService roleService = new RoleService();
            var insertedUserID = InsertUsert(insertUserModel);
            InsertUserRole insertUserRole = new InsertUserRole()
            {
                RoleID = insertUserModel.RoleID,
                UserID = insertedUserID
            };
            roleService.InsertUserRoles(insertUserRole);
        }

        public void UpdateUser(UpdateUserModel updateUserModel)
        {
            var selectedUser = dbContext.Users.FirstOrDefault(x => x.UserID == updateUserModel.UserID);
            selectedUser.UserName = updateUserModel.UserName;
            selectedUser.Password = updateUserModel.Password;
            selectedUser.Phone = updateUserModel.Phone;
            selectedUser.Email = updateUserModel.Email;
            dbContext.SaveChanges();
        }

        public UpdateUserModel GetUserByUserIDForUpdate(int userID)
        {
            var user = dbContext.Users.Where(x => x.UserID == userID).Select(x => new UpdateUserModel
            {
                UserID = x.UserID,
                UserName = x.UserName,
                Password = x.Password,
                Email = x.Email,
                Phone = x.Phone
            }).FirstOrDefault();

            return user;
        }

        public void DeleteUser(int userID)
        {
            var selectedUser = dbContext.Users.FirstOrDefault(x => x.UserID == userID);

            dbContext.Users.Remove(selectedUser);
            dbContext.SaveChanges();
        }
    }

}
