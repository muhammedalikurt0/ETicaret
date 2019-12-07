using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        [MaxLength(25)]
        public string AddresName { get; set; }
        public string _Address { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}