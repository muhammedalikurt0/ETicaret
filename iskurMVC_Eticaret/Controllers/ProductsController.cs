using iskurMVC_Eticaret.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Controllers
{
    public class ProductsController : Controller
    {
        CategoryService categoryService;
        ProductService productService;
        public ProductsController()
        {
            productService = new ProductService();
            categoryService = new CategoryService();
            ViewBag.Categories = categoryService.GetAllCategories();
        }
        // GET: Products
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (id != null)
            {
                int _id = (int)id;
                var product = productService.GetProductByProductID(_id);
                return View(product);
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
        }
    }
}