using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(length: 20)]
        public string UserName { get; set; }
        [MaxLength(length: 20)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<UserRoles> UserRoles { get; set; }
    }
}