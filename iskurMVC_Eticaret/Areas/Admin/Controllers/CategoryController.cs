using iskurMVC_Eticaret.Areas.Admin.Models.CategoryModels;
using iskurMVC_Eticaret.Areas.Admin.Services;
using iskurMVC_Eticaret.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        CategoryService categoryService;
        public CategoryController()
        {
            categoryService = new CategoryService();
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            var categoryList = categoryService.GetAllCategories();
            return View(categoryList);
        }
        [HttpGet]
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Insert()
        {
            return View();
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Insert(CategoryInsertModel categoryInsertModel)
        {
            categoryService.InsertCategory(categoryInsertModel);
            return RedirectToAction("Index");
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Update(int id)
        {
            var selectedCategory = categoryService.GetCategoryByCategoryID(id);
            if (selectedCategory == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                return View(selectedCategory);
            }
        }
        [CustomerAuthorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Update(CategoryUpdateModel categoryUpdateModel)
        {
            if (categoryUpdateModel != null)
            {
                categoryService.UpdateCategory(categoryUpdateModel);
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

        }
        [CustomerAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}