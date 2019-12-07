using iskurMVC_Eticaret.Models;
using iskurMVC_Eticaret.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Controllers
{
    public class CartController : Controller
    {
        ShoppingCartService shoppingCartService;
        public CartController()
        {
            shoppingCartService = new ShoppingCartService();
        }
        public ActionResult Index()
        {
            if (Session["Cart"] != null)
            {
                if (Session["User"] != null)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Log");
                }

            }
            else
            {
                return RedirectToAction("Index", "Main");
            }

        }
        public ActionResult AddToCart(int id)
        {
            var product = shoppingCartService.AddtoCart(id);
            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
            if (Session["Cart"] != null)
            {
                shoppingCarts = (List<ShoppingCart>)Session["Cart"];
                var IsUpdate = shoppingCarts.FirstOrDefault(x => x.ProductID == product.ProductID);
                if (IsUpdate != null)
                {
                    IsUpdate.Quantity += 1;
                }
                else
                {
                    shoppingCarts.Add(product);
                }

                Session["Cart"] = shoppingCarts;
            }
            else
            {
                shoppingCarts.Add(product);
                Session["Cart"] = shoppingCarts;
            }
            return RedirectToAction("Index", "Main");
        }

        public ActionResult Remove(int id)
        {
            List<ShoppingCart> shoppingCarts = (List<ShoppingCart>)Session["Cart"];
            var deletedProduct = shoppingCarts.FirstOrDefault(x => x.ProductID == id);
            shoppingCarts.Remove(deletedProduct);
            if (shoppingCarts.Count == 0)
            {
                Session.Remove("Cart");
            }
            else
            {
                Session["Cart"] = shoppingCarts;
            }
            return RedirectToAction("Index");
        }
    }
}