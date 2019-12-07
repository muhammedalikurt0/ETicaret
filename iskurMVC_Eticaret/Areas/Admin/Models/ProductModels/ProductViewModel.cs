using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Areas.Admin.Models.ProductModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}