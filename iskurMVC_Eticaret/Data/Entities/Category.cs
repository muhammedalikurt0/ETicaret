using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [MaxLength(length: 50)]
        public string CategoryName { get; set; }
    }
}