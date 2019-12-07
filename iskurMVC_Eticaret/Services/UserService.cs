using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Services
{
    public class UserService
    {
        MVCE_TicaretDbContext DbContext;
        public UserService()
        {
            DbContext = new MVCE_TicaretDbContext();
        }
        public User InsertUser(CreateAccountModel createAccountModel)
        {
            User user = new User()
            {
                UserName = createAccountModel.UserName,
                Password = createAccountModel.Password,
                Phone = createAccountModel.Phone,
                Email = createAccountModel.EMail,
            };
            var insertedUser = DbContext.Users.Add(user);
            DbContext.SaveChanges();

            var RoleUser = DbContext.Roles.FirstOrDefault(x => x.RoleName == "User");
            UserRoles roles = new UserRoles()
            {
                RoleID = RoleUser.RoleID,
                UserID = insertedUser.UserID
            };

            DbContext.UserRoles.Add(roles);
            DbContext.SaveChanges();

            return insertedUser;
        }

        public LoginModel UserLogin(LoginModel loginModel)
        {
            try
            {
                var user = DbContext.Users.FirstOrDefault(x => x.UserName == loginModel.UserName && x.Password == loginModel.Password);
                LoginModel login = new LoginModel();
                login.UserName = user.UserName;
                login.UserID = user.UserID;
                login.Password = user.Password;
                return login;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserModel GetUserByUserID(int userID)
        {
            var user = DbContext.Users.Select(x => new UserModel
            {
                UserID = x.UserID,
                UserName = x.UserName,
                EMail = x.Email,
                Password = x.Password,
                Phone = x.Phone
            }).FirstOrDefault(x => x.UserID == userID);
            return user;
        }

        public void UpdateUser(UserModel userModel)
        {
            var selectedUser = DbContext.Users.FirstOrDefault(x => x.UserName == userModel.UserName);
            selectedUser.UserName = userModel.UserName;
            selectedUser.Phone = userModel.Phone;
            selectedUser.Password = userModel.Password;
            selectedUser.Email = userModel.EMail;
            DbContext.SaveChanges();
        }
    }
}