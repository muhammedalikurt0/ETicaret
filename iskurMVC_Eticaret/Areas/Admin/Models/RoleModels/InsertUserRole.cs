using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Areas.Admin.Models.RoleModels
{
    public class InsertUserRole
    {
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}