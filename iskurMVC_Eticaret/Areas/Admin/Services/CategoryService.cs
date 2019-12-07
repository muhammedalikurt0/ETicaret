using iskurMVC_Eticaret.Areas.Admin.Models.CategoriesModels;
using iskurMVC_Eticaret.Areas.Admin.Models.CategoryModels;
using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iskurMVC_Eticaret.Areas.Admin.Services
{
    public class CategoryService
    {
        MVCE_TicaretDbContext dbContext;

        public CategoryService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }
        public List<CategoryViewModel> GetAllCategories()
        {
            var categoryList = dbContext.Categories.Select(x => new CategoryViewModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).ToList();
            return categoryList;
        }
        public void InsertCategory(CategoryInsertModel categoryInsertModel)
        {
            Category category = new Category()
            {
                CategoryName = categoryInsertModel.CategoryName
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
        public void UpdateCategory(CategoryUpdateModel categoryUpdateModel)
        {
            var selectedCategory = dbContext.Categories.FirstOrDefault(x => x.CategoryID == categoryUpdateModel.CategoryID);

            selectedCategory.CategoryName = categoryUpdateModel.CategoryName;
            dbContext.SaveChanges();
        }
        public void DeleteCategory(int categoryID)
        {
            var selectedCategory = dbContext.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
            dbContext.Categories.Remove(selectedCategory);
            dbContext.SaveChanges();
        }
        public CategoryUpdateModel GetCategoryByCategoryID(int categoryID)
        {
            var selectedCategory = dbContext.Categories.FirstOrDefault(x => x.CategoryID == categoryID);
            CategoryUpdateModel categoryUpdate = new CategoryUpdateModel()
            {
                CategoryID = selectedCategory.CategoryID,
                CategoryName = selectedCategory.CategoryName
            };
            return categoryUpdate;

        }
        public List<SelectListItem> GetAllCategoriesForCmbBox()
        {
            var CategoryList = dbContext.Categories.Select(x => new SelectListItem()
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();
            return CategoryList;
        }
    }
}