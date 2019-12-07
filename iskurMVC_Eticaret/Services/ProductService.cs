using iskurMVC_Eticaret.Data;
using iskurMVC_Eticaret.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Services
{
    public class ProductService
    {
        MVCE_TicaretDbContext dbContext;
        public ProductService()
        {
            dbContext = new MVCE_TicaretDbContext();
        }
        public List<ProductViewModel> GetAllProduct()
        {
            var productList = dbContext.Products.Select(x => new ProductViewModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryName = x.Category.CategoryName,
                Description = x.Description,
                Info = x.Info,
                ImageUrl = x.ImageUrl,
                UnitPrice = x.UnitPrice
            }).ToList();
            return productList;
        }

        public List<ProductViewModel> GetProductsByCategoryID(int categoryID)
        {
            var productList = dbContext.Products.Where(x => x.CategoryID == categoryID).Select(x => new ProductViewModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryName = x.Category.CategoryName,
                Description = x.Description,
                Info = x.Info,
                ImageUrl = x.ImageUrl,
                UnitPrice = x.UnitPrice
            }).ToList();
            return productList;
        }

        public ProductViewModel GetProductByProductID(int productID)
        {
            var product = dbContext.Products.Where(x => x.ProductID == productID).Select(x => new ProductViewModel
            {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                CategoryName = x.Category.CategoryName,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Info = x.Info,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault();
            return product;
        }
    }
}