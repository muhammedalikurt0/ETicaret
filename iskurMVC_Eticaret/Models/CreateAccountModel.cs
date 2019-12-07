using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Models
{
    public class CreateAccountModel
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public int RoleID { get; set; }
    }
}