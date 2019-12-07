using iskurMVC_Eticaret.Areas.Admin.Models.ProductModels;
using iskurMVC_Eticaret.Areas.Admin.Services;
using iskurMVC_Eticaret.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Areas.Admin.Controllers
{

    public class ProductController : Controller
    {
        ProductService productService;
        public ProductController()
        {
            productService = new ProductService();
        }

        // GET: Admin/Product
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var productList = productService.GetAllProducts();
            return View(productList);
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Insert()
        {
            CategoryService categoryService = new CategoryService();
            ViewBag.DropDownCategories = categoryService.GetAllCategoriesForCmbBox();
            return View();
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Insert(ProductInsertModel productInsertModel)
        {
            productService.InsertProduct(productInsertModel);
            return RedirectToAction("Index");
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            CategoryService categoryService = new CategoryService();
            ViewBag.DropDownCategories = categoryService.GetAllCategoriesForCmbBox();
            var product = productService.GetProductByProductID(id);
            return View(product);
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(ProductUpdateModel productUpdateModel)
        {
            productService.UpdateProduct(productUpdateModel);
            return RedirectToAction("Index");
        }
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}