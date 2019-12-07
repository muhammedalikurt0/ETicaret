using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class UserRoles
    {
        [Key, Column(Order = 1)]
        public int RoleID { get; set; }
        [Key, Column(Order = 2)]
        public int UserID { get; set; }
        public virtual Roles Roles { get; set; }
        public virtual User User { get; set; }
    }
}