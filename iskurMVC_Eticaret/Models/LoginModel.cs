﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Models
{
    public class LoginModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}