
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
    public class AddressController : Controller
    {
        AddressService addressService;
        public AddressController()
        {
            addressService = new AddressService();
        }
        // GET: Address
        public ActionResult Index()
        {
            List<AddressModel> address = new List<AddressModel>();
            LoginModel loginModel = (LoginModel)Session["User"];
            var userID = loginModel.UserID;
            address = addressService.GetAddressByUserID(userID);
            return View(address);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(AddressModel addressModel)
        {
            var user = (LoginModel)Session["User"];
            var userID = user.UserID;
            addressModel.UserID = userID;
            addressService.InsertAddres(addressModel);
            return RedirectToAction("Index");
        }

    }
}