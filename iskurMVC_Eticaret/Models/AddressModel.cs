using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Models
{
    public class AddressModel
    {
        public int AddressID { get; set; }
        public string Title { get; set; }
        public string _Address { get; set; }
        public int UserID { get; set; }
    }
}