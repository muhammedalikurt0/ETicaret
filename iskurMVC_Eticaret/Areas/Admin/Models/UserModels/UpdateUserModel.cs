using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Areas.Admin.Models.UserModels
{
    public class UpdateUserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}