using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(length: 50)]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
    }
}