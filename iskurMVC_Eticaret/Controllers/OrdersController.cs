using iskurMVC_Eticaret.Attributes;
using iskurMVC_Eticaret.Models;
using iskurMVC_Eticaret.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Controllers
{
    [ControllerAuthorize(Roles = "User")]
    public class OrdersController : Controller
    {
        AddressService _addressService;
        CreditCardService _creditCardService;
        public OrdersController(AddressService addressService, CreditCardService creditCardService)
        {
            _addressService = addressService;
            _creditCardService = creditCardService;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Session["CreditCard"] = _creditCardService.GetAllCreditCard().Select(x => new SelectListItem
            {
                Text = x.CardTitle + "-" + x.Balance + "₺",
                Value = x.CardID.ToString()
            }).ToList();
            return View();
        }
    }
}