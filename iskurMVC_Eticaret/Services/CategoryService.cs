using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Services
{
    public class CategoryService
    {
        MVCE_TicaretDbContext DbContext;

        public CategoryService()
        {
            DbContext = new MVCE_TicaretDbContext();
        }
        public List<CategoryPartialViewModel> GetAllCategories()
        {
            var category = DbContext.Categories.Select(x => new CategoryPartialViewModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).ToList();
            return category;
        }
    }
}