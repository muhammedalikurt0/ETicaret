
using iskurMVC_Eticaret.Models;
using iskurMVC_Eticaret.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Controllers
{
    public class MainController : Controller
    {
        CategoryService categoryService;
        ProductService productService;
        public MainController()
        {
            categoryService = new CategoryService();
            productService = new ProductService();
        }

        // GET: Main
        [HttpGet]
        public ActionResult Index(int? id)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            ViewBag.Categories = categoryService.GetAllCategories();
            if (id != null)
            {
                int categoryID = (int)id;
                productViewModels = productService.GetProductsByCategoryID(categoryID);
            }
            else
            {
                productViewModels = productService.GetAllProduct();
            }
            return View(productViewModels);
        }
    }
}