using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int AddressID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Orders Order { get; set; }
        [ForeignKey("ProductID")]
        public virtual Products Products { get; set; }
        [ForeignKey("AddressID")]
        public virtual Address Address { get; set; }

    }
}