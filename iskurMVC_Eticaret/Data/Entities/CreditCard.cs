using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data.Entities
{
    public class CreditCard
    {
        [Key]
        public int CardID { get; set; }
        public string CardTitle { get; set; }
        public decimal Balance { get; set; }
        public string IBAN { get; set; }
        public int CVC { get; set; }
        public string CustomerFullName { get; set; }
        public string Valid { get; set; }
    }
}