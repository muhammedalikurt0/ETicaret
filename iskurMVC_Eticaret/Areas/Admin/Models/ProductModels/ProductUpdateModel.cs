using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Areas.Admin.Models.ProductModels
{
    public class ProductUpdateModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }
        public string ImageUrl { get; set; }
    }
}